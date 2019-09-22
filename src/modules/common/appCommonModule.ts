import { NgModule } from "@angular/core";
import { Page } from "./components/pages/page";
import { PageCommands } from "./components/pages/pageCommands";
import { PageContent } from "./components/pages/pageContent";
import { Buttons } from "./components/list/buttons";
import { IconButton } from "./components/icon/iconButton";
import { Grid } from "./components/grid/grid";
import { FormHorizontal } from "./components/forms/formHorizontal";
import { FormInputText } from "./components/forms/formInputText";
import { FormButtons } from "./components/forms/formButtons";
import { Validations } from "./components/directives/validations";
import { BaseButton } from "./components/buttons/baseButton";
import { ButtonPrimary } from "./components/buttons/buttonPrimary";
import {ButtonDefault} from "./components/buttons/buttonDefault";
@NgModule({
    declarations: [
        Page,
        PageCommands,
        PageContent,

        Buttons,

        IconButton,

        Grid,

        FormHorizontal,
        FormInputText,
        FormButtons,

        Validations,
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
        FormButtons,

        Validations,

        BaseButton,
        ButtonPrimary,
        ButtonDefault
    ]
})
export class AppCommonModule {

}