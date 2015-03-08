function printArgsInfo() {
    for (var i = 0; i < arguments.length; i++) {
        console.log(arguments[i] + " " + "(" + typeof(arguments[i]) + ")");
    }
}

printArgsInfo.call(this);
printArgsInfo.call(null, ["string", "array"]);
printArgsInfo.apply(null);
printArgsInfo.apply(null, ["string", "array"]);
