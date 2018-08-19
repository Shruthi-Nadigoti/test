<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserUI.aspx.cs" Inherits="UserInterfaceWebForms.UserUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
  
</head>
<body>
  <div class="container">
  <h2>Registration form</h2>
        <form id="form2" runat="server">
    <div class="form-group">
      <label class="control-label col-sm-2" for="email">FirstName:</label>
      <div class="col-sm-10">
        <input type="email" class="form-control" id="firstname" placeholder="Enter email" name="email"/>
      </div>
    </div>
      <div class="form-group">
      <label class="control-label col-sm-2" for="email">LastName:</label>
      <div class="col-sm-10">
        <input type="email" class="form-control" id="email" placeholder="Enter email" name="email"/>
      </div>
    </div>
      <div class="form-group">
      <label class="control-label col-sm-2" for="email">DateOfBirth:</label><asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
&nbsp;<div class="col-sm-10">
      </div>
    </div>
    <div class="form-group">
      <label class="control-label col-sm-2" for="email">Phone Number:</label>
      <div class="col-sm-10">
        <input type="email" class="form-control" id="email" placeholder="Enter email" name="email"/>
      </div>
    </div>
      <div class="form-group">
      <label class="control-label col-sm-2" for="email">Email:</label>
      <div class="col-sm-10">
        <input type="email" class="form-control" id="email" placeholder="Enter email" name="email"/>
      </div>
    </div>
    <div class="form-group">
      <label class="control-label col-sm-2" for="pwd">Password:</label>
      <div class="col-sm-10">          
        <input type="password" class="form-control" id="pwd" placeholder="Enter password" name="pwd"/>
      </div>
    </div>
   
             <div class="form-group">
      <label class="control-label col-sm-2" for="email">Adress:</label>
      <div class="col-sm-10">
        <input type="email" class="form-control" id="email" placeholder="Enter email" name="email"/>
      </div>
    </div>
             <div class="form-group">        
      <div class="col-sm-offset-2 col-sm-10">
        <button type="submit" class="btn btn-default">Submit</button>
      </div>
    </div>
        </form>
</div>
</body>
</html>
