import { Component, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { ChatComponent } from "../UiComponents/Chat/chat.component";
import { SnackBarHelper } from "../Snackbar/SnackbarHelper";
import { AppUser } from "../Data/AppUser";
import { UsersService } from "../Services/UsersService";

export interface InviteUsersData {
  conversationId: number;
  isMultiSelect: boolean;
}

@Component({
  selector: 'find-users-dialog',
  templateUrl: 'find-users-dialog.html',
})
export class FindUsersDialogComponent {

  public usernameToFind: string;

  public FoundUsers = new Array<AppUser>();

  public SelectedUsers = new Array<AppUser>();

  constructor(
    public dialogRef: MatDialogRef<ChatComponent>,
    @Inject(MAT_DIALOG_DATA) public data: InviteUsersData, public usersService: UsersService, public snackBar: SnackBarHelper) {
    this.SelectedUsers = new Array<AppUser>();
  }

  public async OnFindUsers(): Promise<void> {

    if (this.usernameToFind == '' || this.usernameToFind == null) {
      this.snackBar.openSnackBar('Please enter a username in search bar.', 2);
      return;
    }

    let users = await this.usersService.FindUsersByUsername(this.usernameToFind);

    if (users == null) {
      this.snackBar.openSnackBar('Noone was found.', 2);

      this.FoundUsers = new Array<AppUser>();

    } else {
      this.FoundUsers = [...users];
    }

    if (this.SelectedUsers.length != 0) {
      this.SelectedUsers.splice(0, this.SelectedUsers.length);
    }

    this.usernameToFind = '';
  }

  public onCancelClick() {
    this.dialogRef.close();
  }

  public IsUserSelected(user: AppUser) : boolean {
    return this.SelectedUsers.findIndex((x) => x.id == user.id) != -1;
  }

  public SelectUser(user: AppUser) {
    if (this.IsUserSelected(user)) {

      this.SelectedUsers.splice(this.SelectedUsers.findIndex((x) => x.id == user.id), 1);
      return;

    }

    if (!this.data.isMultiSelect) {
      this.SelectedUsers.splice(0, 1);
    }

    this.SelectedUsers.push(user);
  }

}
