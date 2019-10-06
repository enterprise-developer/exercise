import { HttpModule } from "@angular/http";
import { NgModule } from "@angular/core";
import { Page } from "./components/pages/page";
import { PageCommands } from "./components/pages/pageCommands";
import { PageContent } from "./components/pages/pageContent";
import { Buttons } from "./components/list/buttons";
import { IconButton } from "./components/icons/iconButton";
import {Grid} from "./components/grid/grid";


@NgModule({
    imports: [
        HttpModule
    ],
    declarations: [
        Page,
        PageCommands,
        PageContent,

        Buttons,

        IconButton,

        Grid
    ],
    exports: [
        Page,
        PageCommands,
        PageContent,

        Buttons,

        IconButton,

        Grid
    ]
})
export class AppCommonModule {

}