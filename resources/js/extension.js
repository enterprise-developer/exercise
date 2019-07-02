Array.prototype.firstOrDefault=function(predicator){
    predicator= predicator || function(){return true;};
    let self=this;
    for(let index=0; index<self.length; index++){
        if(!predicator(self[index])){continue;}
        return self[index];
    }
}
Array.prototype.remove=function(item){
    var index = this.indexOf(item);
    if (index > -1) {
        this.splice(index, 1);
    }
    return this;
}
Array.prototype.isEmpty=function(){
    return this.length==0;
}

Array.prototype.clearAll=function(){
    this.length = 0;
}
// Object.prototype.clone=function(){
//     return  JSON.parse(JSON.stringify(this));
// }
Sys = {
    extend: function (dest, source, isClone) {
        var result = !isClone ? dest : Object.clone(dest);
        if (source) {
            for (var property in source) {
                if (!source.hasOwnProperty(property)) { continue; }
                if (typeof result[property] == "object") {
                    result[property] = !result[property] ? {} : result[property];
                    result[property] = window.Sys.extend(result[property], source[property], isClone);
                    continue;
                }
                result[property] = source[property];
            };
        }
        return result;
    },
    inheritInstance: function (parentInstance, childInstance) {
        var func = Object.clone(childInstance);
        func.__proto__ = Object.clone(parentInstance);
        return func;
    },
    inherit: function (parentInstance, childConstructor) {
        childConstructor.prototype = parentInstance;
        childConstructor.prototype.constructor = childConstructor;
    },
    toJson: function (obj, deepLevel, currentLevel) {
        try {
            deepLevel = deepLevel ? deepLevel : 2;
            currentLevel = currentLevel ? currentLevel : 0;
            if (currentLevel > deepLevel) { return ""; }

            if (obj == undefined || obj == null) { return ""; }
            if (!Sys.isObject(obj)) { return JSON.stringify(obj); }

            var json = "";
            for (var property in obj) {
                var value = obj[property];
                json = String.format("{0},{1}:'{2}'", json, property, Sys.toJson(value, deepLevel, currentLevel + 1));
            };
            return "{" + json + "}";
        } catch (e) {
            return "";
        }
    },
    isString: function (object) {
        return typeof object == "string";
    },
    isFunction: function (object) {
        return typeof object == "function";
    },
    getVal: function (obj) {
        if (Sys.isObject(obj)) {
            return Sys.toJson(obj, 0);
        }
        return Sys.isFunction(obj) ? obj() : obj;
    },
    isObject: function (obj) {
        return obj instanceof Object;
    },
    emptyFn: function () {
        return function () { };
    },
    emptyObj: {}
};

String.format = function () {
    var args = arguments;
    if (typeof args[0] !== "string") {
        args = args[0];
    }
    var inputStr = args[0],
        paramIndex;
    for (paramIndex = 0; paramIndex < args.length - 1; paramIndex++) {
        var data = Sys.getVal(args[paramIndex + 1]);
        var reg = new RegExp("\\{" + paramIndex + "\\}", "gm");
        inputStr = inputStr.replace(reg, data);
    }
    return inputStr;
};
String.toCamelCase=function(text){
    if(!text){return "";}
    return text.charAt(0).toLowerCase() + text.slice(1);
}