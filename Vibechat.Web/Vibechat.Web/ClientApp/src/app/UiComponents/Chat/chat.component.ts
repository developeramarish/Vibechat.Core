import {Component, OnInit, ViewChild} from "@angular/core";
import {Chat} from "../../Data/Chat";
import {AuthService} from "../../Auth/AuthService";
import {MatDialog, MatDrawer} from "@angular/material";
import {animate, state, style, transition, trigger} from "@angular/animations";
import {ConversationsFormatter} from "../../Formatters/ConversationsFormatter";
import {MessagesComponent} from "../Messages/messages.component";
import {AppUser} from "../../Data/AppUser";
import {AddGroupDialogComponent} from "../../Dialogs/AddGroupDialog";
import {GroupInfoDialogComponent} from "../../Dialogs/GroupInfoDialog";
import {SearchListComponent} from "../../Search/searchlist.component";
import {UserInfoDialogComponent} from "../../Dialogs/UserInfoDialog";
import {UsersService} from "../../Services/UsersService";
import {ChatsService} from "../../Services/ChatsService";
import {ThemesService} from "../../Theming/ThemesService";
import {ChooseContactDialogComponent} from "../../Dialogs/ChooseContactDialog";
import {SnackBarHelper} from "../../Snackbar/SnackbarHelper";
import {DeviceService} from "../../Services/DeviceService";
import {Router} from "@angular/router";

@Component({
  selector: 'chat-root',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css'],
  animations: [
    trigger('slideIn', [
      state('*', style({ 'overflow-y': 'hidden' })),
      state('void', style({ 'overflow-y': 'hidden' })),
      transition('* => void', [
        style({ height: '*' }),
        animate(250, style({ height: 0 }))
      ]),
      transition('void => *', [
        style({ height: '0' }),
        animate(250, style({ height: '*' }))
      ])
    ])
  ]
})
export class ChatComponent implements OnInit {

  public SearchString: string;

  @ViewChild(MessagesComponent, { static: false }) messages: MessagesComponent;
  @ViewChild(MatDrawer, { static: true }) sideDrawer: MatDrawer;
  @ViewChild(SearchListComponent, { static: false }) searchList: SearchListComponent;
  over: any;

  constructor(
    public dialog: MatDialog,
    public formatter: ConversationsFormatter,
    public auth: AuthService,
    private usersService: UsersService,
    private conversationsService: ChatsService,
    private themesService: ThemesService,
    private snackBar: SnackBarHelper,
    private device: DeviceService,
    private router: Router) { }

  get IsSecureChatsSupported() {
    return this.device.isSecureChatsSupported;
  }

  async ngOnInit(): Promise<void> {
    await this.auth.RefreshLocalData();

    await this.UpdateConversations();

    await this.usersService.UpdateUserInfo(this.auth.User.id);

    await this.usersService.UpdateContacts();
  }

  public IsDarkTheme() {
    return this.themesService.currentThemeName == 'dark';
  }

  public SwitchTheme(name: string) {
    this.themesService.changeTheme(name);
  }

  public async OnViewGroupInfo(group: Chat) : Promise<void> {

    if (!group.isGroup) {
      this.OnViewUserInfo(group.dialogueUser, group);
      return;
    }

    const groupInfoRef = this.dialog.open(GroupInfoDialogComponent, {
      width: '450px',
      autoFocus: false,
      panelClass: "profile-dialog",
      data: {
        Conversation: group,
        user: this.auth.User,
        ExistsInThisGroup: this.conversationsService.ExistsIn(group.id)
      }
    });

    groupInfoRef.afterOpened().subscribe(async () => {
      await this.conversationsService.UpdateExisting(group);

      if (!groupInfoRef.componentInstance) {
        return;
      }

      groupInfoRef.componentInstance.data.Conversation = group;
    });

    groupInfoRef.componentInstance
      .OnViewUserInfo
      .subscribe((user: AppUser) => this.OnViewUserInfo(user, null));

    groupInfoRef.componentInstance
      .OnJoinGroup
      .subscribe((group: Chat) => {
        groupInfoRef.close();
        this.OnJoinGroup(group);
      });
  }

  public ChangeChat(chat: Chat) {
    this.conversationsService.ChangeConversation(chat);
  }

  public OnLogOut(): void {
    this.auth.LogOut();
    this.conversationsService.OnLogOut();
  }

  public CreateSecureChat() {
    const chooseContactRef = this.dialog.open(ChooseContactDialogComponent, {
      width: '450px'
    });

    chooseContactRef.beforeClosed().subscribe(
      (user) => {
        if (!user) {
          return;
        }

        if (!this.conversationsService.CreateSecureChat(user)) {
          this.snackBar.openSnackBar('Unable to create the chat with this user. Probably there already exists one.', 3);
        }
      }
    )
  }

  public OnJoinGroup(conversation: Chat) {
    this.SearchString = '';
    this.conversationsService.JoinGroup(conversation);
  }

  public async OnViewUserInfo(user: AppUser, chat: Chat) {
    const userInfoRef = this.dialog.open(UserInfoDialogComponent, {
      width: '450px',
      autoFocus: false,
      panelClass: "profile-dialog",
      data: {
        user: user,
        currentUser: this.auth.User,
        conversation: chat
      }
    });

    userInfoRef.afterOpened().subscribe(async () => {
      let updatedUser = await this.usersService.UpdateUserInfo(user.id);

      if (!updatedUser) {
        return;
      }

      if (!userInfoRef.componentInstance) {
        return;
      }

      if (this.auth.User.id == updatedUser.id) {
        userInfoRef.componentInstance.data.currentUser = updatedUser;
      } else {
        userInfoRef.componentInstance.data.user = updatedUser;
      }
    });
  }

  public CreateDialogWith(user: AppUser) {
    this.conversationsService.CreateDialogWith(user, false);
  }

  public async Search() {
    if (this.SearchString == null || this.SearchString == '') {
      return;
    }

    await this.searchList.Search();
  }

  public CreateGroup() {

    this.sideDrawer.close();

    const dialogRef = this.dialog.open(AddGroupDialogComponent, {
      width: '250px'
    });

    dialogRef.beforeClosed().subscribe(async result => {

      if (!result || !result.name) {
        return;
      }

      await this.conversationsService.CreateGroup(result.name, result.isPublic);
    });
  }

  public IsConversationSelected(): boolean {
    return this.conversationsService.IsConversationSelected();
  }

  public async UpdateConversations() {
    await this.conversationsService.UpdateConversations();
  }

  public async ChangeConversationTo(conversation: Chat) {
    this.SearchString = '';
    await this.conversationsService.ChangeConversation(null);
    await this.conversationsService.ChangeConversation(conversation);
  }

  public async ChangeConversation(conversation: Chat) {
    //if we were on search screen, we should hide it

    this.SearchString = '';

    await this.conversationsService.ChangeConversation(conversation);
  }

  public IsMobileDevice() {
    return window.innerWidth < ConversationsFormatter.MinPixelsDesktop;
  }

  //input events

  public async OnSendMessage(message: string) {
    await this.conversationsService.SendMessage(message, this.conversationsService.CurrentConversation);
    this.messages.ScrollToLastMessage();
  }
}