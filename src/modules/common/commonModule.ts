import { NgModule } from "@angular/core";
import { Page } from "./components/pages/page";
import { PageContent } from "./components/pages/pageContent";
import { Grid } from "./components/grid/grid";
@NgModule({
    declarations: [
        Page,
        PageContent,
        Grid
    ],
    exports: [
        Page,
        PageContent,
        Grid
    ]
})
export class AppCommonModule {

}