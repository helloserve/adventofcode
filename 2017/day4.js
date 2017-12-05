require('./string.js');

part1 = (input) => splitOnNewLine(input).reduce((accumulator, currentLine, currentIndex, array) => 
    parseLine(currentLine) ? accumulator + 1 : accumulator, 0);

part2 = (input) => splitOnNewLine(input).reduce((accumulator, currentLine, currentIndex, array) =>
    parseLine(currentLine, true) ? accumulator + 1 : accumulator, 0);

parseLine = (line, checkAnagram) => {
    return splitOnWhiteSpace(line).reduce((outerResult, outerWord, outerIndex, outerArray) => {
        return outerResult && outerArray.reduce((innerResult, innerWord, innerIndex, innerArray) => {
            if (outerIndex === innerIndex) {
                return innerResult && true;
            }

            if (outerWord === innerWord) {
                return false;
            }

            if (checkAnagram && isAnagram(outerWord, innerWord)) {
                return false;
            }

            return innerResult && true;
        }, true);
    }, true);
}

isAnagram = (a, b) => {
    if (a.length !== b.length) {
        return false;
    }

    for (let i = 0; i < a.length; i++) {
        const a_letter = a[i];
        
        for (let j = 0; j < b.length; j++) {
            const b_letter = b[j];
            
            if (a_letter === b_letter) {
                var s = b.substr(0, j) + '-' + (j = b.length ? b.substr(j + 1) : '');
                b = s;
                break;
            }
        }
    }

    return (/^-*$/g).test(b);
}
    
module.exports =  { part1, part2 }

part2('iiii oiii ooii oooi oooo');