//String.prototype.splitOnNewLine = () => this.split(/[\r\n]+/g);
//String.prototype.splitOnWhiteSpace = () => this.split(/\s/g);

splitOnNewLine = (str) => str.split(/[\r\n]+/g);
splitOnWhiteSpace = (str) => str.split(/\s/g);

module.exports = { splitOnNewLine, splitOnWhiteSpace }