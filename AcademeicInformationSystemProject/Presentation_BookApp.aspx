<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Presentation_BookApp.aspx.cs" Inherits="AcademeicInformationSystemProject.Presentation_BookApp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Academic Information System</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <fieldset style="width: 470px">
          <legend>3 Tier Example for insert and bind Book Details</legend>
          <table>
              <tr>
                  <td>Book Name* :</td>
                  <td>
                      <asp:TextBox ID="txtBookName" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="rfvBookName" runat="server" ErrorMessage="Book Name Cann't be left blank" ControlToValidate="txtBookName" Display ="Dynamic" ForeColor="Red" SetFocusOnError ="True"></asp:RequiredFieldValidator>

                  </td>
              </tr>
              <tr>
                  <td>Author*</td>
                  <td>
                      <asp:TextBox ID="txtAuthorName" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="rfvAuthor" runat="server" ErrorMessage="Author Name Cann't be left blank" ControlToValidate="txtAuthorName" Display ="Dynamic" ForeColor="Red" SetFocusOnError ="True"></asp:RequiredFieldValidator>
                  </td>
              </tr>
              <tr>
                  <td>Publisher*</td>
                  <td>
                      <asp:TextBox ID="txtPublisherName" runat="server"></asp:TextBox>
                     <!-- <asp:RegularExpressionValidator ID="rfvPublisher" runat="server" ErrorMessage="Publisher Name Cann't be blank" ControlToValidate="txtPublisherName" Display ="Dynamic" ForeColor="Red" SetFocusOnError ="True"></asp:RegularExpressionValidator>  -->
                  </td>
              </tr>
              <tr>
                  <td>Price*</td>
                  <td>
                      <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox> 
                      
                     <!-- <asp:RegularExpressionValidator ID="rgePrice" runat="server" ControlToValidate="txtPrice" Display="Dynamic" ErrorMessage="Enter Numeric Only" ForeColor="Red" SetFocusOnError="true" ValidationExpression="^\d*[0-9](|.\d*[0-9]|)*$"></asp:RegularExpressionValidator>-->
                  </td>
              </tr>
              <tr>
                  <td></td>
              <td><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" style="height: 26px" /></td>
              </tr>
              <tr>
                  <td colspan="2"><asp:Label ID="lblStatus" runat="server" Text="server"></asp:Label></td>
              </tr>
          </table>
          <br />
          <asp:GridView ID="grdBookDetails" runat="server" DataKeyNames="BookId" AutoGenerateColumns="False" 
               OnPageIndexChanging="grdBookDetails_PageIndexChanging" 
              OnRowCancelingEdit="grdBookDetails_RowCancelingEdit" 
              OnRowDeleting="grdBookDetails_RowDeleting" 
              OnRowEditing="grdBookDetails_RowEditing" 
              OnRowUpdating="grdBookDetails_RowUpdating" AllowPaging="true" PageSize="5" CellPadding="4" ForeColor="#333333" grodl="None">
              <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
              <Columns>
                   <asp:TemplateField HeaderText="Book Name">
                       <ItemTemplate>
                           <asp:Label ID="lblBookName" runat="server" Text='<%# Eval("BookName") %>'></asp:Label>
                       </ItemTemplate>
                       <EditItemTemplate>
                           <asp:TextBox ID="txtBookNameEdit" runat="server" Text='<%# Eval("BookName") %>'></asp:TextBox>
                       </EditItemTemplate>
                   </asp:TemplateField>
                  <asp:TemplateField HeaderText="Author">
                      <ItemTemplate>
                          <asp:Label ID="lblAuthor" runat="server"  Text='<%# Eval("Author") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtAuthorEdit" runat="server" Text='<%# Eval("Author") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                      <ItemTemplate>
                          <asp:Label ID="lblPublisher" runat="server" Text='<%#("Publisher") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtPublisherEdit" runat="server" Text='<%#("Publisher") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                      <ItemTemplate>
                          <asp:Label ID="lblPrice" runat="server" Text='<%#("Price") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtPriceEdit" runat="server" Text='<%#("Price") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate>
                           <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/Images/edit_icon.jpg" CommandName="Update" CausesValidation="false" />
                       </ItemTemplate>
                      <EditItemTemplate>
                          <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CommandName="Update" CausesValidation="false">LinkButton</asp:LinkButton>
                          <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false">LinkButton</asp:LinkButton>
                      </EditItemTemplate>
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                  <asp:TemplateField>
                      <ItemTemplate>
                          <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/Images/delete.jpg" CommandName="Delete" CausesValidation="false" onclientclick="return confirm('Are you sure want to delete?')"/>
                      </ItemTemplate>
                      <EditItemTemplate></EditItemTemplate>
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>

              </Columns>
              <EditRowStyle BackColor="#2461BF" />
              <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
              <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
              <RowStyle BackColor="#EFF3FB" />
              <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
              <SortedAscendingCellStyle BackColor="#F5F7FB" />
              <SortedAscendingHeaderStyle BackColor="#6D95E1" />
              <SortedDescendingCellStyle BackColor="#E9EBEF" />
              <SortedDescendingHeaderStyle BackColor="#4870BE" />
          </asp:GridView>
      </fieldset>
    </div>
    </form>
</body>
</html>
