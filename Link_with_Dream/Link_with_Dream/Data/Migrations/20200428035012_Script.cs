using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Link_with_Dream.Data.Migrations
{
    public partial class Script : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonalObjective",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profession",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePic",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Religion",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AcademicQualification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamName = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Institute = table.Column<string>(nullable: true),
                    Board = table.Column<string>(nullable: true),
                    PassingYear = table.Column<int>(nullable: false),
                    Result = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    IsPublic = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicQualification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicQualification_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CareerInformation",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CarrierObjective = table.Column<string>(nullable: true),
                    LookingFor = table.Column<string>(nullable: true),
                    AvailableFor = table.Column<string>(nullable: true),
                    PreferedJobCatagory1 = table.Column<string>(nullable: true),
                    PreferedJobCatagory2 = table.Column<string>(nullable: true),
                    PreferedJobCatagory3 = table.Column<string>(nullable: true),
                    PreferdArea1 = table.Column<string>(nullable: true),
                    PreferdArea2 = table.Column<string>(nullable: true),
                    ExpectedSalary = table.Column<string>(nullable: true),
                    IsPublic = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareerInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessege",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Messege = table.Column<string>(nullable: true),
                    MessegeTime = table.Column<DateTime>(nullable: false),
                    SenderId = table.Column<string>(nullable: true),
                    ReceiverId = table.Column<string>(nullable: true),
                    IsSeen = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessege", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessege_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChatMessege_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Objective = table.Column<string>(nullable: true),
                    CoverPic = table.Column<string>(nullable: true),
                    About = table.Column<string>(nullable: true),
                    Services = table.Column<string>(nullable: true),
                    CaseStudy = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Instalation = table.Column<DateTime>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Complaint",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplaintText = table.Column<string>(nullable: true),
                    RefImage = table.Column<string>(nullable: true),
                    ComplaintTime = table.Column<DateTime>(nullable: false),
                    ComplentById = table.Column<string>(nullable: true),
                    ComplentToId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Complaint_AspNetUsers_ComplentById",
                        column: x => x.ComplentById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Complaint_AspNetUsers_ComplentToId",
                        column: x => x.ComplentToId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Friendship",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<string>(nullable: true),
                    ReceiverId = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendship", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friendship_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Friendship_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Objective = table.Column<string>(nullable: true),
                    TermsCondition = table.Column<string>(nullable: true),
                    MenbersType = table.Column<string>(nullable: true),
                    CoverImage = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationText = table.Column<string>(nullable: true),
                    NotifyTime = table.Column<DateTime>(nullable: false),
                    SenderId = table.Column<string>(nullable: true),
                    ReceiverId = table.Column<string>(nullable: true),
                    IsSeen = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notification_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalSkill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    IsPublic = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessionalSkill_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    IsPublic = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecialQualification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseTitle = table.Column<string>(nullable: true),
                    Topic = table.Column<string>(nullable: true),
                    Institute = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    IsPublic = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialQualification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialQualification_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkingExperience",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    CompanyAddress = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    IsPublic = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingExperience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingExperience_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyPeople",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyPeople", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyPeople_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyPeople_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContentPost",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Heading = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    PostTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false),
                    CGPosterId = table.Column<string>(nullable: true),
                    PostType = table.Column<int>(nullable: false),
                    DeadLine = table.Column<DateTime>(nullable: false),
                    JobType = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    XMStartTime = table.Column<DateTime>(nullable: false),
                    XMEndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentPost_AspNetUsers_CGPosterId",
                        column: x => x.CGPosterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContentPost_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentPost_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentPost_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupPeople",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    GroupId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupPeople", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupPeople_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupPeople_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContentComents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Coment = table.Column<string>(nullable: true),
                    ComentTime = table.Column<DateTime>(nullable: false),
                    ContentPostId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentComents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentComents_ContentPost_ContentPostId",
                        column: x => x.ContentPostId,
                        principalTable: "ContentPost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentComents_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContentLike",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LikeOrUnlike = table.Column<int>(nullable: false),
                    LikeTime = table.Column<DateTime>(nullable: false),
                    ContentPostId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentLike", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentLike_ContentPost_ContentPostId",
                        column: x => x.ContentPostId,
                        principalTable: "ContentPost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentLike_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExamQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionHeading = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ContentPostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamQuestion_ContentPost_ContentPostId",
                        column: x => x.ContentPostId,
                        principalTable: "ContentPost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Option = table.Column<string>(nullable: true),
                    QuestionSerial = table.Column<int>(nullable: false),
                    IsCorrest = table.Column<bool>(nullable: false),
                    ExamQuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionAnswer_ExamQuestion_ExamQuestionId",
                        column: x => x.ExamQuestionId,
                        principalTable: "ExamQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionAnswerId = table.Column<int>(nullable: false),
                    IsCorrect = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateAnswer_QuestionAnswer_QuestionAnswerId",
                        column: x => x.QuestionAnswerId,
                        principalTable: "QuestionAnswer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateAnswer_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicQualification_UserId",
                table: "AcademicQualification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateAnswer_QuestionAnswerId",
                table: "CandidateAnswer",
                column: "QuestionAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateAnswer_UserId",
                table: "CandidateAnswer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessege_ReceiverId",
                table: "ChatMessege",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessege_SenderId",
                table: "ChatMessege",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPeople_CompanyId",
                table: "CompanyPeople",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPeople_UserId",
                table: "CompanyPeople",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaint_ComplentById",
                table: "Complaint",
                column: "ComplentById");

            migrationBuilder.CreateIndex(
                name: "IX_Complaint_ComplentToId",
                table: "Complaint",
                column: "ComplentToId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentComents_ContentPostId",
                table: "ContentComents",
                column: "ContentPostId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentComents_UserId",
                table: "ContentComents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentLike_ContentPostId",
                table: "ContentLike",
                column: "ContentPostId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentLike_UserId",
                table: "ContentLike",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentPost_CGPosterId",
                table: "ContentPost",
                column: "CGPosterId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentPost_CompanyId",
                table: "ContentPost",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentPost_GroupId",
                table: "ContentPost",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentPost_UserId",
                table: "ContentPost",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestion_ContentPostId",
                table: "ExamQuestion",
                column: "ContentPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Friendship_ReceiverId",
                table: "Friendship",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Friendship_SenderId",
                table: "Friendship",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupPeople_GroupId",
                table: "GroupPeople",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupPeople_UserId",
                table: "GroupPeople",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_ReceiverId",
                table: "Notification",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_SenderId",
                table: "Notification",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalSkill_UserId",
                table: "ProfessionalSkill",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_UserId",
                table: "Project",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswer_ExamQuestionId",
                table: "QuestionAnswer",
                column: "ExamQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialQualification_UserId",
                table: "SpecialQualification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingExperience_UserId",
                table: "WorkingExperience",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicQualification");

            migrationBuilder.DropTable(
                name: "CandidateAnswer");

            migrationBuilder.DropTable(
                name: "CareerInformation");

            migrationBuilder.DropTable(
                name: "ChatMessege");

            migrationBuilder.DropTable(
                name: "CompanyPeople");

            migrationBuilder.DropTable(
                name: "Complaint");

            migrationBuilder.DropTable(
                name: "ContentComents");

            migrationBuilder.DropTable(
                name: "ContentLike");

            migrationBuilder.DropTable(
                name: "Friendship");

            migrationBuilder.DropTable(
                name: "GroupPeople");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "ProfessionalSkill");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "SpecialQualification");

            migrationBuilder.DropTable(
                name: "WorkingExperience");

            migrationBuilder.DropTable(
                name: "QuestionAnswer");

            migrationBuilder.DropTable(
                name: "ExamQuestion");

            migrationBuilder.DropTable(
                name: "ContentPost");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PersonalObjective",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Profession",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePic",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Religion",
                table: "AspNetUsers");
        }
    }
}
