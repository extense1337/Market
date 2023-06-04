using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Database.Migrations
{
    /// <inheritdoc />
    public partial class namingconvention : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPicture_Products_ProductId",
                table: "ProductPicture");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_SellerId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPicture",
                table: "ProductPicture");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "products");

            migrationBuilder.RenameTable(
                name: "ProductPicture",
                newName: "product_picture");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "users",
                newName: "user_name");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "users",
                newName: "full_name");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "products",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "products",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "products",
                newName: "seller_id");

            migrationBuilder.RenameColumn(
                name: "PricingType",
                table: "products",
                newName: "pricing_type");

            migrationBuilder.RenameColumn(
                name: "DisplayName",
                table: "products",
                newName: "display_name");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SellerId",
                table: "products",
                newName: "ix_products_seller_id");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "product_picture",
                newName: "content");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "product_picture",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UploadDate",
                table: "product_picture",
                newName: "upload_date");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "product_picture",
                newName: "product_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPicture_ProductId",
                table: "product_picture",
                newName: "ix_product_picture_product_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_products",
                table: "products",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_product_picture",
                table: "product_picture",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_product_picture_products_product_id",
                table: "product_picture",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_products_users_seller_id",
                table: "products",
                column: "seller_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_product_picture_products_product_id",
                table: "product_picture");

            migrationBuilder.DropForeignKey(
                name: "fk_products_users_seller_id",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "pk_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "pk_products",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "pk_product_picture",
                table: "product_picture");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "product_picture",
                newName: "ProductPicture");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_name",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "full_name",
                table: "Users",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Products",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "seller_id",
                table: "Products",
                newName: "SellerId");

            migrationBuilder.RenameColumn(
                name: "pricing_type",
                table: "Products",
                newName: "PricingType");

            migrationBuilder.RenameColumn(
                name: "display_name",
                table: "Products",
                newName: "DisplayName");

            migrationBuilder.RenameIndex(
                name: "ix_products_seller_id",
                table: "Products",
                newName: "IX_Products_SellerId");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "ProductPicture",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ProductPicture",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "upload_date",
                table: "ProductPicture",
                newName: "UploadDate");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "ProductPicture",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "ix_product_picture_product_id",
                table: "ProductPicture",
                newName: "IX_ProductPicture_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPicture",
                table: "ProductPicture",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPicture_Products_ProductId",
                table: "ProductPicture",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_SellerId",
                table: "Products",
                column: "SellerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
