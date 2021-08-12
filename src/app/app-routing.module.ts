import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BuyInsuranceComponent } from './buy-insurance/buy-insurance.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';

const routes: Routes = [
    {path:'',component:NavBarComponent},
    {path:'buy1',component: BuyInsuranceComponent},
    {path:"test/:type/:rno",component:NavBarComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponents=[BuyInsuranceComponent,NavBarComponent]
