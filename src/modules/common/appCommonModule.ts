import { NgModule } from "@angular/core";
import { Page } from "./components/pages/page";
import { PageCommand } from "./components/pages/pageCommand";
import { Buttons } from "./components/list/buttons";
import { IconButton } from "./components/icons/iconButton";
import { FormsModule } from "@angular/forms";
import { HttpModule } from "@angular/http";
import { PageContent } from "./components/pages/pageContent";
import { Grid } from "./components/grid/grid";
@NgModule({
    declarations: [
        Page,
        PageCommand,
        PageContent,

        Buttons,
        IconButton,

        Grid
    ],
    exports: [
        Page,
        PageCommand,
        PageContent,

        Buttons,
        IconButton,

        Grid
    ],
    imports: [
        FormsModule,
        HttpModule
    ]
})
export class AppCommonModule { }