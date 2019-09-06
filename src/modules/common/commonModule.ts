import { NgModule } from "@angular/core";
import { Page } from "./components/pages/page";
import { PageContent } from "./components/pages/pageContent";
import { PageCommand } from "./components/pages/pageCommand";
import { Grid } from "./components/grid/grid";
import { Buttons } from "./components/list/buttons";
import { IconButton } from "./components/icons/iconButton";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { FormHorizontal } from "./components/forms/formHorizontal";
import { FormButtons } from "./components/forms/formButtons";
import { FormTextInput } from "./components/forms/formTextInput";
import { Validation } from "./components/directives/validation";
import { PrimaryButton } from "./components/buttons/primaryButton";
import { DefaultButton } from "./components/buttons/defaultButton";
import { BaseButton } from "./components/buttons/baseButton";
@NgModule({
    imports: [CommonModule, FormsModule],
    declarations: [
        /* page */
        Page,
        PageContent,
        PageCommand,

        /* form */
        FormHorizontal,
        FormButtons,
        FormTextInput,
        /* grid */
        Grid,

        /* buttons */
        Buttons,
        BaseButton,
        PrimaryButton,
        DefaultButton,

        /* icon */
        IconButton,

        /* validation */
        Validation

    ],
    exports: [
        /* page */
        Page,
        PageContent,
        PageCommand,

        /* form */
        FormHorizontal,
        FormButtons,
        FormTextInput,
        /* grid */
        Grid,

        /* buttons */
        Buttons,
        BaseButton,
        PrimaryButton,
        DefaultButton,

        /* icon */
        IconButton,

        /* validation */
        Validation
    ]
})
export class AppCommonModule {

}