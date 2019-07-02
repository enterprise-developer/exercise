import { BaseModel, IGridOption, PromiseFactory, IResourceManager } from "@app/common";
import { UserGroups } from "./userGroups";

export class UserGroupsModel extends BaseModel {
    public options: IGridOption;
    constructor(page: UserGroups) {
        super();
        let i18nHelper: IResourceManager = page.i18nHelper;
        this.options = {
            dataSource: PromiseFactory.create(),
            columns: [
                { field: "name", title: i18nHelper.resolve("userGroups.name") },
                { field: "description", title: i18nHelper.resolve("userGroups.description") }
            ],
            actions: []
        };
    }
}