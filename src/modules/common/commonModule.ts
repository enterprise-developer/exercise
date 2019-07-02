import { CommonModule } from "@angular/common";
import { HttpModule } from "@angular/http";
import { FormsModule } from "@angular/forms";
import { NgModule } from "@angular/core";

import {IconEdit} from "./components/icons/edit";
import {IconPreview} from "./components/icons/preview";
import {BaseIcon} from "./components/icons/baseIcon";
import {Page} from "./components/layout/page";
import {PageContent} from "./components/layout/pageContent";
import {PageCommand} from "./components/layout/pageCommand";
import {FormHorizontal} from "./components/form/formHorizontal";
import {FormButtons} from "./components/form/formButtons";
import {FormTextInput} from "./components/form/formTextInput";
import {Validation} from "./components/validation";
import {Grid} from "./components/grid/grid";

@NgModule({
    imports:[CommonModule, HttpModule, FormsModule],
    declarations:[
        /* form */
        FormHorizontal, FormTextInput, FormButtons, 
        /* validation */
        Validation,
        /* icon */
        IconEdit, IconPreview, BaseIcon, 
        /* layout */
        Page, PageContent, PageCommand,
        /* Grid */
        Grid
    ],
    exports:[
        /* form */
        FormHorizontal, FormTextInput, FormButtons, 
        /* validation */
        Validation,
        /* icon */
        IconEdit, IconPreview, BaseIcon, 
        /* layout */
        Page, PageContent, PageCommand,
        /* Grid */
        Grid
    ]
})
export class AppCommonModule{}