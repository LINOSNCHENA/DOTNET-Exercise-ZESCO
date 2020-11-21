FRONTEND

npx create-react-app zanaco
npm install --save bootstrap  
npm install --save reactstrap react react-dom
npm install --save axios
npm install react-router-dom --save 

BACKEND

dotnet restore
dotnet list package

Add-Migration "InitialCreate"
Update-Database

INPUT

{
    "cardownername":"5OCENTS",
     "CVV":"231",
      "CARDNUMBER":"1234567892345678",
       "expirationdate":"12/11"    
}


{
    "Name":"5OCENTS",
     "RollNo":"231",
      "Class":"1234567892345678",
       "Address":"12/11"    
}


Name:'',  
RollNo:'',  
Class:'',  
Address:''  
} 