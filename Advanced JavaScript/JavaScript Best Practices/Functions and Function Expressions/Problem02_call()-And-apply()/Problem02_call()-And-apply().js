function printArgsInfo() {
    var len = arguments.length,
        i;

    for (i = 0; i < len; i+=1) {
        console.log(arguments[i] + ' ' + '(' + typeof(arguments[i]) + ')');
    }
}

printArgsInfo.call(this);
printArgsInfo.call(null, ['string', 'array']);
printArgsInfo.apply(null);
printArgsInfo.apply(null, ['string', 'array']);