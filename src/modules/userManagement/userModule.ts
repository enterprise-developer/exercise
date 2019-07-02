import { NgModule } from "@angular/core";
import { UserRoutes } from "./userRoutes";
import { FormsModule } from "@angular/forms";
@NgModule({
    imports: [
        UserRoutes, FormsModule
    ]
})
export class UserModule {

}