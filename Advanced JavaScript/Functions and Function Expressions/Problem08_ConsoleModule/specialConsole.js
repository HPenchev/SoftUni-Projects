var specialConsole = (function() {
    function writeLine() {
        var output = takeOutput(arguments);
        console.log(output);
    }

    function writeError() {
        var output = takeOutput(arguments);
        console.error(output);
    }

    function writeWarning() {
        var output = takeOutput(arguments);
        console.warn(output);
    }

    function writeInfo() {
        var output = takeOutput(arguments);
        console.info(output);
    }

    function takeOutput(args) {
        var placeholders;
        var i;
        var phrase;
        var argumentReplacers = [];
        var numberOfReplacersExpected;
        var output;

        for (i = 0; i < args.length; i += 1) {
            args[i] = args[i].toString();
        }

        phrase = args[0];

        placeholders = takePlaceholders(phrase);
        if (!placeholders) {
            return phrase;
        }

        for (i = 1; i < args.length; i += 1) {
            argumentReplacers[i - 1] = args[i];
        }

        numberOfReplacersExpected = takeNumberOfReplacersExpected(placeholders);

        if (numberOfReplacersExpected > argumentReplacers.length) {
            throw new Error("Invalid number of arguments");
        }

        output = replacePlaceholders(phrase, placeholders, argumentReplacers);
        return output;
    }

    function takePlaceholders(phrase) {
        var i = 0;
        var placeholders;
        var pattern;
        pattern = /{\d+}/g;
        placeholders = phrase.match(pattern);
        return placeholders;
    }

    function takeNumberOfReplacersExpected(placeholders) {
        var i = 0;
        var maxNumber = -1;
        var number;

        for (i = 0; i < placeholders.length; i+=1) {
            number = takePlaceholderAsNumber(placeholders[i]);
            if (number > maxNumber) {
                maxNumber = number;
            }
        }

        return maxNumber + 1;
    }
    function takePlaceholderAsNumber(placeholder) {
        var placeholderAsNumber
        var number;
        var pattern = /\d+/g;

        number = placeholder.match(pattern);
        placeholderAsNumber = parseInt(number);

        return placeholderAsNumber;
    }

    function replacePlaceholders(phrase, placeholders, argumentReplacers) {
        var replacer;
        var i;
        var position;

        for (i = 0; i < placeholders.length; i++) {
            position = takePlaceholderAsNumber(placeholders[i]);
            replacer = argumentReplacers[position];

            phrase = phrase.replace(placeholders[i], replacer);
        }

        return phrase;
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning,
        writeInfo: writeInfo
    };
})();

specialConsole.writeLine("Message: hello");
specialConsole.writeLine("Message: {0}", "hello");
specialConsole.writeLine("Object: {0}", { name: "Gosho", toString: function() { return this.name }});
specialConsole.writeError("Error: {0}", "A fatal error has occurred.");
specialConsole.writeWarning("Warning: {0}", "You are not allowed to do that!");
specialConsole.writeInfo("Info: {0}", "Hi there! Here is some info for you.");
specialConsole.writeError("Error object: {0}", { msg: "An error happened", toString: function() { return this.msg }});