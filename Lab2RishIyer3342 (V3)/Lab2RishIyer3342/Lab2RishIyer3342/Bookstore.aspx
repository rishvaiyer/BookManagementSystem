<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="~/Bookstore.aspx.cs" Inherits="Lab2RishIyer3342.Bookstore" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8" />

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" ></script>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" ></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <link href="https://fonts.googleapis.com/css2?family=Bungee&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Mukta:wght@500&display=swap" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="style.css" />
    <title></title>
</head>
<body>
       <p>
&nbsp;</p>
       <img id="bookPic" src="pics/bookFall.jpg" /> <div id="title">Brilliant Books </div>

<div  class="note">
        <form runat="server">

       <div id="basicInfo">
 <div id="basicInfoHeader"><asp:Label ID="lblBasicInfoHeader" runat="server"> Enter Your Information:  </asp:Label></div>

           <br />
     
<div class="row">

<asp:TextBox id="txtStudentID" runat="server" class="form-control col-md-3" placeholder="Student ID" /> <br /><br />
        <asp:Label ID="lblStudentIDError" runat="server" style="color:red">*</asp:Label>
 </div>
       
           <br />
           <div class="row">
<asp:TextBox id="txtName" runat="server" class="form-control col-md-3" placeholder="Full Name" />   <asp:Label ID="lblNameError" runat="server" style="color:red"> *</asp:Label>

      </div>
           <br />
      <div class="row">

  
<asp:TextBox id="txtPhoneNumber" runat="server" class="form-control col-md-3" placeholder="Phone Number"  /> <asp:Label ID="lblPhoneNumberError" runat="server" style="color:red" >*</asp:Label>
          </div>

           <br />


      
<div class="row">
<asp:TextBox id="txtAddress"  class="form-control col-md-3" placeholder="Address"  runat="server" /> <asp:Label ID="lblAddressError" runat="server" style="color:red" > * </asp:Label>
    </div>
      <br />

        <br />
        <asp:Label ID="lblCampus" runat="server" Text="Select A Campus"></asp:Label>   
        <asp:DropDownList ID="ddlCampus" runat="server">
            <asp:ListItem Value="Main"> Main Campus </asp:ListItem>
                <asp:ListItem Value="CenterCity"> Center City Campus </asp:ListItem>
                <asp:ListItem Value="Ambler"> Ambler Campus </asp:ListItem>
                <asp:ListItem Value="Japan"> Japan Campus </asp:ListItem>
                <asp:ListItem Value="Rome"> Rome Campus </asp:ListItem>
        </asp:DropDownList>

             <asp:Label ID="lblReciept" runat="server" style="color:black; font-size: 20px; text-align:center">

             </asp:Label>
     </div>
        <br />
                 <asp:Label ID="lblError" runat="server" style="color:red; font-size: 20px;"></asp:Label>
      
              
       
         <asp:Label ID="lblgvMRTitle" runat="server" style="color:black; font-size: 40px; text-align:center" Text="Management Report"></asp:Label>
        <asp:GridView ID="gvMR" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="100%" OnSelectedIndexChanged="gvMR_SelectedIndexChanged" BorderStyle="None">
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" ForeColor="White" Font-Bold="True" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
        <asp:Label ID="lblOrderError" runat="server" style="z-index: 1;" Text=" "></asp:Label>
<br />
       
        <asp:GridView ID="gvBooks" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnSelectedIndexChanged="gvBooks_SelectedIndexChanged" Width="100%" BorderStyle="None">
            <Columns>
              <asp:TemplateField HeaderText="Select">
           <ItemTemplate>
               <asp:CheckBox ID="chkSelect" runat="server" />
           </ItemTemplate>       
              </asp:TemplateField>
                <asp:BoundField DataField="Title" HeaderText="Title" ReadOnly="True" SortExpression="Title" />
                <asp:BoundField DataField="Authors" HeaderText="Authors" ReadOnly="True" SortExpression="Authors" />
                <asp:BoundField DataField="ISBN" HeaderText="ISBN" ReadOnly="True" SortExpression="ISBN" />
                 <asp:BoundField DataField="BasePrice" HeaderText="BasePrice" ReadOnly="True" SortExpression="BasePrice" DataFormatString="{0:c}" />
                <asp:TemplateField HeaderText="Type">
                       <ItemTemplate>
              <asp:DropDownList ID="ddlType" runat="server">
                  <asp:ListItem Value="Paperback"> Paperback </asp:ListItem>
                           <asp:ListItem Value="Hardcopy"> Hardcopy </asp:ListItem>
                   <asp:ListItem Value="Ebook"> Ebook </asp:ListItem>
              </asp:DropDownList>
                           
           </ItemTemplate> 

                </asp:TemplateField>

                <asp:TemplateField HeaderText="Rent or Buy">
                    <ItemTemplate>
                          <asp:DropDownList ID="ddlRentOrBuy" runat="server">
                  <asp:ListItem Value="Rent"> Rent </asp:ListItem>
                           <asp:ListItem Value="Buy"> Buy </asp:ListItem>
                
              </asp:DropDownList>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="txtQuantity" runat="server">
                            
                            </asp:TextBox>
                       
                    </ItemTemplate>



                </asp:TemplateField>

            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" ForeColor="White" Font-Bold="True" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
      
        
      
       <asp:Button class="btn btn-outline-dark" ID="btnOrder" runat="server" OnClick="btnOrder_Click" Text="Order Books" />
        <asp:Label ID="lblYourOrder" runat="server" style="color:black; font-size: 40px; text-align:center" Text="Your Book Order"></asp:Label>
        <asp:GridView ID="gvOrder" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" CellPadding="4" Width="100%" ForeColor="Black" GridLines="Horizontal" ShowFooter="True" OnSelectedIndexChanged="gvOrder_SelectedIndexChanged" BorderStyle="None">
            <Columns>
             
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="ISBN" HeaderText="ISBN" SortExpression="ISBN" />
                <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                <asp:BoundField DataField="RentOrBuy" HeaderText="Rent Or Buy" SortExpression="RentOrBuy" />
                 <asp:BoundField DataField="BasePrice" HeaderText="BasePrice" SortExpression="BasePrice" DataFormatString="{0:c}" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" SortExpression="TotalPrice" DataFormatString="${0:c}" />
               
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="Black" HorizontalAlign="Right" BackColor="White" />
            <SelectedRowStyle BackColor="#CC3333" ForeColor="White" Font-Bold="True" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>

               <asp:Button ID="btnSelectMore" class="btn btn-outline-dark" runat="server" OnClick="btnSelectMore_Click" Text="Edit Order"/>
            <asp:Button ID="btnManagementReport"  class="btn btn-outline-dark" runat="server" OnClick="btnManagementReport_Click" Text="View Management Report" />
    </form>
</div>
      
</body>
</html>

