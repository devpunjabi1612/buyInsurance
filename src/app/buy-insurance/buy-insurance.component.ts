import { Component, OnInit, Input } from '@angular/core';
import { Register } from '../Models/Register';
import { NgForm } from '@angular/forms';
// import { VechicleRegistrationService } from './vechicle-registration.service';
import { ActivatedRoute, Router } from '@angular/router';
import { VechicleRegistrationService } from '../vechicle-registration.service';




type VehicleDetails = {
  id:number;
  name:string;
  category?:string[];
};

type vehicleDetails = VehicleDetails[];

@Component({
  selector: 'app-buy-insurance',
  templateUrl: './buy-insurance.component.html',
  styleUrls: ['./buy-insurance.component.css']
})
export class BuyInsuranceComponent implements OnInit {



  
  vehicleBrand:string = "";
  
  register:Register;

  rForm:NgForm;
  
  @Input() vehicleDetail:vehicleDetails=[];
  reg: Register = new Register();



  constructor(private route: ActivatedRoute,private router:Router, private vechicleReg : VechicleRegistrationService ) {
    this.vehicleDetail=[
      {id : 1 , name: "Car", category:["Maruti", "Honda"]},
      {id : 2 , name: "Bike", category:["Bajaj", "Royal Enfield"]},
    ]
    // this.reg.userName = "chirag";
    // this.reg.userPassword = "Chirag@12";
    // this.reg.userEmail = "chirag@lti.com";
    // this.reg.userPhone = "9090909090";
  }

  ngOnInit(): void {
    
   
  }

  onChange(event: any) {
    console.log(event.name);
  }

  submitted():void{
    console.log();
    //this.reg=data;
    this.vechicleReg.postVechicle(this.reg).subscribe(data => console.log("abcd")); 
    this.router.navigate(['/test'+'/'+ this.reg.VehicleType+'/'+this.reg.RegistrationNumber]);
  }



}
function vechicles(vechicles: any) {
  throw new Error('Function not implemented.');
}

