String.prototype.startsWith = function(substring){
    var startingPosition = 0;
    var endingPosition = substring.length;
    var result = this.substring(startingPosition, endingPosition);

    if (result === substring) {
        return true;
    } else {
        return false;
    }
}

String.prototype.endsWith = function(substring){
    var endingPosition = this.length;
    var startingPosition = this.length - substring.length;
    var result = this.substring(startingPosition, endingPosition);

    return (result === substring)
}

String.prototype.endsWith = function(substring){
    var endingPosition = this.length;
    var startingPosition = this.length - substring.length;
    var result = this.substring(startingPosition, endingPosition);

    return (result === substring)
}

String.prototype.left = function(count){
    var result = this.substring(0, count);

    return result
}

String.prototype.right = function(count){
    var result = this.substring(this.length - count, this.length);

    return result
}

String.prototype.padLeft = function(count, character){
    character = character || " ";
    var numberOfPaddingCharacters = count - this.length;
    var result = "";
    var i = 0;

    for (i = 0; i < numberOfPaddingCharacters; i+=1) {
        result += character;
    }

    result += this;

    return result
}

String.prototype.padRight = function(count, character){
    character = character || " ";
    var numberOfPaddingCharacters = count - this.length;
    var result = "" + this;
    var i = 0;

    for (i = 0; i < numberOfPaddingCharacters; i+=1) {
        result += character;
    }

    return result
}

String.prototype.repeat = function(count){
    var result = "";
    var i = 0;

    for (i = 0; i < count; i+=1) {
        result += this;
    }

    return result
}

var example;

example = "This is an example string used only for demonstration purposes.";
console.log(example.startsWith("This"));
console.log(example.startsWith("this"));
console.log(example.startsWith("other"));

example = "This is an example string used only for demonstration purposes.";
console.log(example.endsWith("poses."));
console.log(example.endsWith ("example"));
console.log(example.startsWith("something else"));

example = "This is an example string used only for demonstration purposes.";
console.log(example.left(9));
console.log(example.left(90));

example = "This is an example string used only for demonstration purposes.";
console.log(example.right(9));
console.log(example.right(90));

example = "abcdefgh";
console.log(example.left(5).right(2));

example = "hello";
console.log(example.padLeft(5));
console.log(example.padLeft(10));
console.log(example.padLeft(5, "."));
console.log(example.padLeft(10, "."));
console.log(example.padLeft(2, "."));

example = "hello";
console.log(example.padRight(5));
console.log(example.padRight(10));
console.log(example.padRight(5, "."));
console.log(example.padRight(10, "."));
console.log(example.padRight(2, "."));

example = "*";
console.log(example.repeat(5));
console.log("~".repeat(3));

console.log("*".repeat(5).padLeft(10, "-").padRight(15, "+"));