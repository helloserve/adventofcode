part1 = (input) => input.split('').reduce((accumulator, currentValue, currentIndex, array) => {
    if (currentIndex < array.length - 1) {
        return (currentValue === array[currentIndex + 1]) ? accumulator + parseInt(currentValue, 10) : accumulator;
    }

    return (currentValue === array[0] ? accumulator + parseInt(currentValue, 10) : accumulator);
}, 0);

part2 = (input) => input.split('').reduce((accumulator, currentValue, currentIndex, array) => {
    var nextIndex = (array.length / 2) + currentIndex;
    if (nextIndex >= array.length) {
        nextIndex -= input.length;            
    }        

    return (currentValue === array[nextIndex]) ? accumulator + parseInt(currentValue, 10) : accumulator;
}, 0);

    
module.exports = { part1, part2 }
