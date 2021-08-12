import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  
  slideIndex:number = 0;

  images = [  
    { img: "assets/Images/HomePage1.jpg" },  
    { img: "assets/Images/HomePage2.jpg" },  
    { img: "assets/Images/TravelInsurance.jpg"}
    
      
  ];
 
  slideConfig = {  
    "slidesToShow": 2,  
    "slidesToScroll": 2,  
    "dots": true,  
    "infinite": true  
  };
}  

