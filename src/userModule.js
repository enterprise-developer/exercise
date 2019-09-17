System.register(["@angular/core", "@angular/platform-browser", "@angular/forms", "./userRoutes", "./layout"], function (exports_1, context_1) {
    "use strict";
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __moduleName = context_1 && context_1.id;
    var core_1, platform_browser_1, forms_1, userRoutes_1, layout_1, UserModule;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (platform_browser_1_1) {
                platform_browser_1 = platform_browser_1_1;
            },
            function (forms_1_1) {
                forms_1 = forms_1_1;
            },
            function (userRoutes_1_1) {
                userRoutes_1 = userRoutes_1_1;
            },
            function (layout_1_1) {
                layout_1 = layout_1_1;
            }
        ],
        execute: function () {
            UserModule = /** @class */ (function () {
                function UserModule() {
                }
                UserModule = __decorate([
                    core_1.NgModule({
                        imports: [
                            platform_browser_1.BrowserModule,
                            forms_1.FormsModule,
                            userRoutes_1.UserRoutes
                        ],
                        declarations: [layout_1.Layout],
                        bootstrap: [layout_1.Layout]
                    })
                ], UserModule);
                return UserModule;
            }());
            exports_1("UserModule", UserModule);
        }
    };
});
//# sourceMappingURL=userModule.js.map