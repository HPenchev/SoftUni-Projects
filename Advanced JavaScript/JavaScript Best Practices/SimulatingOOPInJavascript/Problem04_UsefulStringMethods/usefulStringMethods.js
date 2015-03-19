String.prototype.startsWith = function(substring){
    var startingPosition = 0,
        endingPosition = substring.length,
        result = this.substring(startingPosition, endingPosition);

    return result === substring;
}

String.prototype.endsWith = function(substring){
    var endingPosition = this.length,
        startingPosition = this.length - substring.length,
        result = this.substring(startingPosition, endingPosition);

    return (result === substring);
}

String.prototype.endsWith = function(substring){
    var endingPosition = this.length,
        startingPosition = this.length - substring.length,
        result = this.substring(startingPosition, endingPosition);

    return (result === substring);
}

String.prototype.left = function(count){
    return this.substring(0, count);
}

String.prototype.right = function(count){
    return this.substring(this.length - count, this.length);
}

String.prototype.padLeft = function(count, character){
    var numberOfPaddingCharacters = count - this.length,
        result = '',
        i = 0;

    character = character || ' ';

    for (i = 0; i < numberOfPaddingCharacters; i+=1) {
        result += character;
    }

    result += this;

    return result;
}

String.prototype.padRight = function(count, character){
    var numberOfPaddingCharacters = count - this.length,
        result = '' + this,
        i = 0;

    character = character || ' ';

    for (i = 0; i < numberOfPaddingCharacters; i+=1) {
        result += character;
    }

    return result;
}

String.prototype.repeat = function(count){
    var result = '',
        i;

    for (i = 0; i < count; i+=1) {
        result += this;
    }

    return result;
}

var example;

example = 'This is an example string used only for demonstration purposes.';
console.log(example.startsWith('This'));
console.log(example.startsWith('this'));
console.log(example.startsWith('other'));

example = 'This is an example string used only for demonstration purposes.';
console.log(example.endsWith('poses.'));
console.log(example.endsWith ('example'));
console.log(example.startsWith('something else'));

example = 'This is an example string used only for demonstration purposes.';
console.log(example.left(9));
console.log(example.left(90));

example = 'This is an example string used only for demonstration purposes.';
console.log(example.right(9));
console.log(example.right(90));

example = 'abcdefgh';
console.log(example.left(5).right(2));

example = 'hello';
console.log(example.padLeft(5));
console.log(example.padLeft(10));
console.log(example.padLeft(5, '.'));
console.log(example.padLeft(10, '.'));
console.log(example.padLeft(2, '.'));

example = 'hello';
console.log(example.padRight(5));
console.log(example.padRight(10));
console.log(example.padRight(5, '.'));
console.log(example.padRight(10, '.'));
console.log(example.padRight(2, '.'));

example = '*';
console.log(example.repeat(5));
console.log('~'.repeat(3));

console.log('*'.repeat(5).padLeft(10, '-').padRight(15, '+'));