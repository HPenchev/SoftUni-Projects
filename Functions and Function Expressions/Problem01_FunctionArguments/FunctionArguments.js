printArgsInfo = new function() {
    for (var i = 0; i < arguments.length; i++) {
        console.log(arguments[i] + " " + "(" + typeof(arguments[i]) + ")");
    }
}