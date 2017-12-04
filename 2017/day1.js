var File = require('./file.js');

function Day1() {

    this.part1File = (filepath, callback) => new File().load(filepath, data => callback(this.part1(data)));

    this.part1 = (input) => input.split('').reduce((accumulator, currentValue, currentIndex, array) => {
            if (currentIndex < array.length - 1) {
                return (currentValue === array[currentIndex + 1]) ? accumulator + parseInt(currentValue, 10) : accumulator;
            }

            return (currentValue === array[0] ? accumulator + parseInt(currentValue, 10) : accumulator);
        }, 0);

    this.part2File = (filepath, callback) => new File().load(filepath, data => callback(this.part2(data)));

    this.part2 = (input) => input.split('').reduce((accumulator, currentValue, currentIndex, array) => {
        var nextIndex = (array.length / 2) + currentIndex;
        if (nextIndex >= array.length) {
            nextIndex -= input.length;            
        }        

        return (currentValue === array[nextIndex]) ? accumulator + parseInt(currentValue, 10) : accumulator;
    }, 0);
}
    
module.exports = Day1;