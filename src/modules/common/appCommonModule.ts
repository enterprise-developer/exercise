import { HttpModule } from "@angular/http";
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { Page } from "./components/pages/page";
import { PageCommands } from "./components/pages/pageCommands";
import { PageContent } from "./components/pages/pageContent";
import { Buttons } from "./components/list/buttons";
import { IconButton } from "./components/icons/iconButton";
import { Grid } from "./components/grid/grid";
import { FormHorizontal } from "./components/forms/formHorizontal";
import { FormInputText } from "./components/forms/formInputText";
import { FormInputNumber } from "./components/forms/formInputNumber";
import { FormButtons } from "./components/forms/formButtons";
import { Validations } from "./components/directives/validations";
import { Numeric } from "./components/directives/numeric";
import { BaseButton } from "./components/buttons/baseButton";
import {ButtonPrimary} from "./components/buttons/buttonPrimary";
import {ButtonDefault} from "./components/buttons/buttonDefault";

@NgModule({
    imports: [
        HttpModule,
        CommonModule,
        FormsModule
    ],
    declarations: [
        Page,
        PageCommands,
        PageContent,

        Buttons,

        IconButton,

        Grid,

        FormHorizontal,
        FormInputText,
        FormInputNumber,
        FormButtons,

        Validations,
        Numeric,

        BaseButton,
        ButtonPrimary,
        ButtonDefault
    ],
    exports: [
        Page,
        PageCommands,
        PageContent,

        Buttons,

        IconButton,

        Grid,

        FormHorizontal,
        FormInputText,
        FormInputNumber,
        FormButtons,

        Validations,
        Numeric,

        BaseButton,
        ButtonPrimary,
        ButtonDefault
    ]
})
export class AppCommonModule {

}