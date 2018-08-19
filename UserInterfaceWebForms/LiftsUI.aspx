<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LiftsUI.aspx.cs" Inherits="UserInterfaceWebForms.LiftsUI" %>

<html lang="en">
<head runat="server">
    <style>
        .square {
  height: 226px;
  width: 150px;
}
  .numberbutton{
      width:50px;
      height:50px;

  }
  div.inline { float:left; }
        .auto-style1 {
            margin-left: 200px;
        }
        .selectedFloors{
            width:100px;
            height:3px;
            background-color:antiquewhite;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
   <div class="inline" style="height:400px;width:600px;border-color:blueviolet;border-width:10px;background-color:aliceblue">
       
       <div class="square inline" style="background-color:cornflowerblue">Selected Floors:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 1<br />
           <div class="selectedFloors" >1 2&nbsp; 3</div><br />
           <br />
           <br />
           <br />
           <br />
           <br />
           <br />
           <br />
           <br />
           UP</div>
       <div class="square inline" style="background-color: darkorange">&nbsp;Selected Floors:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 2<br />
           <div class="selectedFloors" >1 2&nbsp; 4</div><br />
           <br />
           &nbsp;
           <br />
           <br />
           <br />
           <br />
           <br />
           <br />
           <br />
           DOWN</div>
       <div class="square inline" style="background-color: darkseagreen">Selected Floors:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 3<br />
           <div class="selectedFloors" >1 2&nbsp; 4</div><br />
           <br />
           <br />
           <br />
           <br />
           <br />
           <br />
           <br />
           <br />
           UP</div>
       <div class="square " style="background-color:dodgerblue">selected Floors:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 4<br />
           <div class="selectedFloors" >1 2&nbsp; 4</div><br />
           <br />
           <br />
           <br />
           <br />
           <br />
           <br />
           <br />
           <br />
           DOWN</div>
       
       <div class="square inline" style="background-color:indianred">Selected Floor:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 5<br />
           <div class="selectedFloors" >1 2&nbsp; 4</div><br />
           <br />
           <br />
           <br />
           <br />
           <br />
           <br />
           <br />
           <br />
           UP
       </div>
       <div class="square inline" style="background-color:darkseagreen">Selected Floor:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 6<br />
           <div class="selectedFloors" >1 2&nbsp; 4</div><br />
           <br />
           <br />
           <br />
           <br />
           <br />
           <br />
           <br />
           <br />
           UP</div>
       <div class="square inline" style="background-color:rebeccapurple">Selected Floors:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 7<br />
           <div class="selectedFloors" >1 2&nbsp; 4</div><br />
           <br />
           <br />
           <br />
           <br />
           <br />
           <br />
           <br />
           <br />
           IDEAL</div>
       <div class="square inline" style="background-color:darksalmon">Selected Floors:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 8<br />
           <div class="selectedFloors" >1 2&nbsp; 4</div><br />
           <br />
           <br />
           <br />
           <br />
           <br />
           <br />
           <br />
           <br />
           IDEAL<br />
       </div>


   </div>
    <div style="height:400px;width:70px" class="inline"></div>
   <div style="height:437px; width:155px; border-color:brown;border-width:10px;background-color:yellowgreen">Selected Floors:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 4<br />
       <br />
       <br />
       <div class="selectedFloors" >1 2&nbsp; 4</div><br />
       <br />
       <br />
       <br />
       <br />
       <br />
       <br />
       <br />
       <br />
       <br />
       <br />
       <br />
       <br />
       <br />
       <br />
       <br />
       <br />
       <br />
       <br />
       UP</div>

        <h4 style="margin-left:100px;">&nbsp;Enter the floor number:</h4>
 <div class="inline" style="height:200px;width:200px;border-color:blueviolet;border-width:10px;background-color:aliceblue; margin-left: 200px;margin-top:10px;">
       
     <asp:Button ID="Button4" runat="server" Text="1" class="numberbutton"/>
     <asp:Button ID="Button1" runat="server" Text="2"  class="numberbutton"/>
     <asp:Button ID="Button2" runat="server" Text="3" class="numberbutton" /><br class="auto-style1"/>
     <asp:Button ID="Button10" runat="server" Text="4"  class="numberbutton"/>
     <asp:Button ID="Button11" runat="server" Text="5"  class="numberbutton"/>
     <asp:Button ID="Button3" runat="server" Text="6"  class="numberbutton" />
<br class="auto-style1">
     <asp:Button ID="Button5" runat="server" Text="7"  class="numberbutton" />
     <asp:Button ID="Button7" runat="server" Text="8"  class="numberbutton" />
     <asp:Button ID="Button6" runat="server" Text="9"  class="numberbutton"/><br class="auto-style1">
     <asp:Button ID="Button8" runat="server" Text="A"  class="numberbutton" />
     <asp:Button ID="Button9" runat="server" Text="0"  class="numberbutton" />
     <asp:Button ID="Button12" runat="server" Text="B"  class="numberbutton"/>
     </br>


   </div>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Assigned Lift:"></asp:Label>
     &nbsp; 3</form>
</body>
</html>
