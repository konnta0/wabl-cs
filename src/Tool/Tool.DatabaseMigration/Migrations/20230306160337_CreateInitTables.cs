using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseMigration.Migrations
{
    public partial class CreateInitTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "dept_emp",
                columns: table => new
                {
                    emp_no = table.Column<int>(type: "int", nullable: false),
                    dept_no = table.Column<string>(type: "varchar(4)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    from_date = table.Column<DateTime>(type: "date", nullable: false),
                    to_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dept_emp", x => new { x.emp_no, x.dept_no });
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    dept_no = table.Column<string>(type: "char(4)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dept_name = table.Column<string>(type: "varchar(40)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeptEmpEntityDeptNo = table.Column<string>(type: "varchar(4)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeptEmpEntityEmpNo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.dept_no);
                    table.ForeignKey(
                        name: "FK_departments_dept_emp_DeptEmpEntityEmpNo_DeptEmpEntityDeptNo",
                        columns: x => new { x.DeptEmpEntityEmpNo, x.DeptEmpEntityDeptNo },
                        principalTable: "dept_emp",
                        principalColumns: new[] { "emp_no", "dept_no" });
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    emp_no = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    birth_date = table.Column<DateTime>(type: "date", nullable: false),
                    first_name = table.Column<string>(type: "varchar(14)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_name = table.Column<string>(type: "varchar(16)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    gender = table.Column<string>(type: "enum('M', 'F')", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    hire_date = table.Column<DateTime>(type: "date", nullable: false),
                    DeptEmpEntityDeptNo = table.Column<string>(type: "varchar(4)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeptEmpEntityEmpNo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.emp_no);
                    table.ForeignKey(
                        name: "FK_employees_dept_emp_DeptEmpEntityEmpNo_DeptEmpEntityDeptNo",
                        columns: x => new { x.DeptEmpEntityEmpNo, x.DeptEmpEntityDeptNo },
                        principalTable: "dept_emp",
                        principalColumns: new[] { "emp_no", "dept_no" });
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "salaries",
                columns: table => new
                {
                    emp_no = table.Column<int>(type: "int", nullable: false),
                    from_date = table.Column<DateTime>(type: "date", nullable: false),
                    salary = table.Column<int>(type: "int", nullable: false),
                    to_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salaries", x => new { x.emp_no, x.from_date });
                    table.ForeignKey(
                        name: "FK_salaries_employees_emp_no",
                        column: x => x.emp_no,
                        principalTable: "employees",
                        principalColumn: "emp_no",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "titles",
                columns: table => new
                {
                    emp_no = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(50)", nullable: false),
                    from_date = table.Column<DateTime>(type: "date", nullable: false),
                    to_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_titles", x => new { x.emp_no, x.from_date });
                    table.ForeignKey(
                        name: "FK_titles_employees_emp_no",
                        column: x => x.emp_no,
                        principalTable: "employees",
                        principalColumn: "emp_no",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "DeptName",
                table: "departments",
                column: "dept_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_departments_DeptEmpEntityEmpNo_DeptEmpEntityDeptNo",
                table: "departments",
                columns: new[] { "DeptEmpEntityEmpNo", "DeptEmpEntityDeptNo" });

            migrationBuilder.CreateIndex(
                name: "DeptNo",
                table: "dept_emp",
                column: "dept_no");

            migrationBuilder.CreateIndex(
                name: "IX_employees_DeptEmpEntityEmpNo_DeptEmpEntityDeptNo",
                table: "employees",
                columns: new[] { "DeptEmpEntityEmpNo", "DeptEmpEntityDeptNo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "salaries");

            migrationBuilder.DropTable(
                name: "titles");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "dept_emp");
        }
    }
}
