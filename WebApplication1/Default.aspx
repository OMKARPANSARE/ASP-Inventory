<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="updatepnl" runat="server">  
<ContentTemplate>  

        <div class="card-body" style="padding-top:20px">

            <div class="row">
                <div class="col-md-4">
                    <p>Name</p>
                    <asp:HiddenField ID="hifildID" runat="server" />
                    <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqword" ControlToValidate="txtName" runat="server" ErrorMessage="*Required"></asp:RequiredFieldValidator>  
                </div>
                <div class="col-md-4">
                     <p>Description</p>
                    <asp:TextBox ID="txtDiscription" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDiscription" runat="server" ErrorMessage="*Required"></asp:RequiredFieldValidator>  

                </div>
                <div class="col-md-4">
                     <p>Quantity</p>
                    <asp:TextBox ID="txtQuntity" Type="number" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtQuntity" runat="server" ErrorMessage="*Required"></asp:RequiredFieldValidator>  

                </div>
            </div>
            
             <div class="row" style="padding-top:20px">
                <div class="col-md-4">
                    <p>Price</p>
                    <asp:TextBox Type="number" ID="txtPrice" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtPrice" runat="server" ErrorMessage="*Required"></asp:RequiredFieldValidator>  

                </div>
                <div class="col-md-4">
                     <p>Supplier</p>
                    <asp:TextBox ID="txtSupplier" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtSupplier" runat="server" ErrorMessage="*Required"></asp:RequiredFieldValidator>  

                </div>
                <div class="col-md-4" style="padding-top:25px">
                   <asp:Button ID="btnAdd" CssClass="btn btn-primary" OnClick="BtnAdd_Onclick" runat="server" Text="Add" />  
                    <asp:Button ID="btnUpdate" Visible="false" CssClass="btn btn-info" OnClick="BtnUpdate_Onclick" runat="server" Text="Update" />
                </div>
            </div>



            <div class="table-responsive" style="padding-top:20px">
                <table class="table table-bordered" id="dataTabl1e" width="100%" cellspacing="0">
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Description</th>
                            <th>Quantity</th>
                            <th>Price</th>
                            <th>Supplier</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tfoot>
                        <tr>
                            <th>Name</th>
                            <th>Description</th>
                            <th>Quntity</th>
                            <th>Price</th>
                            <th>Supplier</th>
                            <th>Action</th>
                        </tr>
                    </tfoot>
                    <tbody>                        
                        <asp:Repeater ID="rptItem" runat="server">    
                            <ItemTemplate>
                                <tr>
                                    <td style="display:none;">
                                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblQuntity" runat="server" Text='<%# Eval("Quntity") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblSupplier" runat="server" Text='<%# Eval("SupplierName") %>' />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnEdit" CssClass="btn btn-primary" runat="server" CausesValidation="False" OnClick="btnEdit_Onclick" Text="Edit" />
                                        <asp:Button ID="BtnDelete" CssClass="btn btn-danger" runat="server" CausesValidation="False" OnClick="BtnDelete_Onclick" Text="Delete" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                       
                       
                    </tbody>
                </table>
            </div>
        </div>
    </ContentTemplate>
    </asp:UpdatePanel>





</asp:Content>
