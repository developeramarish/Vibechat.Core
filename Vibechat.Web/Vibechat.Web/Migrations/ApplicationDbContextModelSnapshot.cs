﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VibeChat.Web;

namespace Vibechat.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("VibeChat.Web.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("ConnectionId");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("FullImageUrl");

                    b.Property<bool>("IsOnline");

                    b.Property<bool>("IsPublic");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("LastSeen");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("ProfilePicImageURL");

                    b.Property<string>("RefreshToken");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("VibeChat.Web.ConversationDataModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthKeyId");

                    b.Property<string>("CreatorId");

                    b.Property<string>("FullImageUrl");

                    b.Property<bool>("IsGroup");

                    b.Property<bool>("IsPublic");

                    b.Property<bool>("IsSecure");

                    b.Property<string>("Name");

                    b.Property<int?>("PublicKeyId");

                    b.Property<string>("ThumbnailUrl");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("PublicKeyId");

                    b.ToTable("Conversations");
                });

            modelBuilder.Entity("VibeChat.Web.Data.DataModels.AttachmentKindDataModel", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Name");

                    b.ToTable("AttachmentKinds");

                    b.HasData(
                        new
                        {
                            Name = "img"
                        },
                        new
                        {
                            Name = "file"
                        });
                });

            modelBuilder.Entity("VibeChat.Web.Data.DataModels.MessageAttachmentDataModel", b =>
                {
                    b.Property<int>("AttachmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AttachmentKindName");

                    b.Property<string>("AttachmentName");

                    b.Property<string>("ContentUrl");

                    b.Property<long>("FileSize");

                    b.Property<int>("ImageHeight");

                    b.Property<int>("ImageWidth");

                    b.Property<int?>("MessageId");

                    b.HasKey("AttachmentID");

                    b.HasIndex("AttachmentKindName");

                    b.HasIndex("MessageId")
                        .IsUnique();

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("VibeChat.Web.Data.SettingsDataModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(2048);

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("VibeChat.Web.DeletedMessagesDataModel", b =>
                {
                    b.Property<int>("MessageID");

                    b.Property<string>("UserId");

                    b.HasKey("MessageID");

                    b.ToTable("DeletedMessages");
                });

            modelBuilder.Entity("VibeChat.Web.MessageDataModel", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ConversationID");

                    b.Property<string>("EncryptedPayload");

                    b.Property<int?>("ForwardedMessageMessageID");

                    b.Property<bool>("IsAttachment");

                    b.Property<string>("MessageContent");

                    b.Property<int>("State");

                    b.Property<DateTime>("TimeReceived");

                    b.Property<string>("UserId");

                    b.HasKey("MessageID");

                    b.HasIndex("ConversationID");

                    b.HasIndex("ForwardedMessageMessageID");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("VibeChat.Web.UsersConversationDataModel", b =>
                {
                    b.Property<string>("UserID");

                    b.Property<int>("ChatID");

                    b.HasKey("UserID", "ChatID");

                    b.HasIndex("ChatID");

                    b.ToTable("UsersConversations");
                });

            modelBuilder.Entity("Vibechat.Web.Data.DataModels.ContactsDataModel", b =>
                {
                    b.Property<string>("FirstUserID");

                    b.Property<string>("SecondUserID");

                    b.HasKey("FirstUserID", "SecondUserID");

                    b.HasIndex("SecondUserID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Vibechat.Web.Data.DataModels.ConversationsBansDataModel", b =>
                {
                    b.Property<int>("ChatID");

                    b.Property<string>("UserID");

                    b.HasKey("ChatID", "UserID");

                    b.HasIndex("UserID");

                    b.ToTable("ConversationsBans");
                });

            modelBuilder.Entity("Vibechat.Web.Data.DataModels.DhPublicKeyDataModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Generator");

                    b.Property<string>("Modulus");

                    b.HasKey("Id");

                    b.ToTable("PublicKeys");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Generator = "5",
                            Modulus = "30445704021091515043589705032000416743065879523138206374507066714396902967826274025631618229965138647563750555154979126280906579122837150373480202328346842570774085859182345981586646516929523275488501196012664339665000259691166799681559154401985737875054416305014473301299223214280232526356243298947531967598860851745809118777180045083632452217526977904029644599066308131296163393000164130258492650715234142089972808359667482827732851432028411017393736987205804161070813960388610459820505679155787472727171508004197344905155937150738660205704682022704155225348753967503171179256418887643829768064151315264948430447643"
                        },
                        new
                        {
                            Id = 2,
                            Generator = "5",
                            Modulus = "32263366888482059323243883015844747463965633534460381695780102759488099321032708334304505667666637685300505592369993636530815881102308957048371822607863954733817431065032603081782824700230973378782698023906415337615400031203101471874900241507489668722465641666896931753727311596566091264518919851218789756402628304989296109806612534970945915938124598750842390238411160204981182640889415926127674121044185527248690460313606448767420374921388319398313924659508283461791477125909269820467245948516679916104219176576965841073678423303547601277304956836098698284063305292637873086496892392420324931515705463719457818391903"
                        },
                        new
                        {
                            Id = 3,
                            Generator = "5",
                            Modulus = "24686716193249294655435300797497114211078959859276664073733717026830954181574388585315694045547212768961613342303599456962906305799342423705644564610104313711924785307130075216907652332970869326682805755857773148743676260028590179245424907542602604826824659365364084160548368532184623254146224405505128422317198793170098375902826740530739724436141448566436832702729067122102229640982472203935696282671800474814097452256414678537282324994774580722689119929861200126328720274469821909551794989267104991749216243041288976425117086205131154327259025718994944932831286131755855732747670825247733961413482774928847145848683"
                        },
                        new
                        {
                            Id = 4,
                            Generator = "5",
                            Modulus = "20511064139841876696208229254000064895498308708985023576653435535421416417594516774924493827744623544847238987846574744361120463310357785783241148249314307516370165566636708802131190227740623365100379446244224186700951777543056890843857560451632206080364698149346737149295461623896888713887833761226282705077573490187927513477344537509706489902786608552066156656101651000143551974090549989153259917689688908445021764937236819290246070592801026626071949237468671408951883181725105134543274800285933845010517241736518635511601891749900728648705430139444855907139519170754104572729308445072787726322570780369556422739723"
                        },
                        new
                        {
                            Id = 5,
                            Generator = "5",
                            Modulus = "20850965393100772630721381827467472846769974337484934948485962234352705295662792015939788728305700806819038412100331548613067641292812785261491147385725382284428429766310618521703081552913546975030866816165893472445277829294748965421857329404134415647286470036472641032781856997861782897278603448824696922997054565547655636184219624327030090189311608152965483673354384130916454486847897115874140265827339554177255203771867546072260275858144383592611464594638476890150964299365002135998606866470198012882210416522022871618334038010682652038038493600763843805286318397247480947350931175656728334601366362069270360295443"
                        });
                });

            modelBuilder.Entity("Vibechat.Web.Data.DataModels.UsersBansDatamodel", b =>
                {
                    b.Property<string>("BannedByID");

                    b.Property<string>("BannedID");

                    b.HasKey("BannedByID", "BannedID");

                    b.HasIndex("BannedID");

                    b.ToTable("UsersBans");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("VibeChat.Web.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("VibeChat.Web.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VibeChat.Web.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("VibeChat.Web.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VibeChat.Web.ConversationDataModel", b =>
                {
                    b.HasOne("VibeChat.Web.AppUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("Vibechat.Web.Data.DataModels.DhPublicKeyDataModel", "PublicKey")
                        .WithMany()
                        .HasForeignKey("PublicKeyId");
                });

            modelBuilder.Entity("VibeChat.Web.Data.DataModels.MessageAttachmentDataModel", b =>
                {
                    b.HasOne("VibeChat.Web.Data.DataModels.AttachmentKindDataModel", "AttachmentKind")
                        .WithMany()
                        .HasForeignKey("AttachmentKindName");

                    b.HasOne("VibeChat.Web.MessageDataModel", "Message")
                        .WithOne("AttachmentInfo")
                        .HasForeignKey("VibeChat.Web.Data.DataModels.MessageAttachmentDataModel", "MessageId");
                });

            modelBuilder.Entity("VibeChat.Web.DeletedMessagesDataModel", b =>
                {
                    b.HasOne("VibeChat.Web.MessageDataModel", "Message")
                        .WithMany()
                        .HasForeignKey("MessageID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VibeChat.Web.MessageDataModel", b =>
                {
                    b.HasOne("VibeChat.Web.ConversationDataModel", "Chat")
                        .WithMany()
                        .HasForeignKey("ConversationID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VibeChat.Web.MessageDataModel", "ForwardedMessage")
                        .WithMany()
                        .HasForeignKey("ForwardedMessageMessageID");

                    b.HasOne("VibeChat.Web.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("VibeChat.Web.UsersConversationDataModel", b =>
                {
                    b.HasOne("VibeChat.Web.ConversationDataModel", "Conversation")
                        .WithMany()
                        .HasForeignKey("ChatID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VibeChat.Web.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vibechat.Web.Data.DataModels.ContactsDataModel", b =>
                {
                    b.HasOne("VibeChat.Web.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("FirstUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VibeChat.Web.AppUser", "Contact")
                        .WithMany()
                        .HasForeignKey("SecondUserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vibechat.Web.Data.DataModels.ConversationsBansDataModel", b =>
                {
                    b.HasOne("VibeChat.Web.ConversationDataModel", "Conversation")
                        .WithMany()
                        .HasForeignKey("ChatID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VibeChat.Web.AppUser", "BannedUser")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vibechat.Web.Data.DataModels.UsersBansDatamodel", b =>
                {
                    b.HasOne("VibeChat.Web.AppUser", "BannedBy")
                        .WithMany()
                        .HasForeignKey("BannedByID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VibeChat.Web.AppUser", "BannedUser")
                        .WithMany()
                        .HasForeignKey("BannedID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
