require('./string.js');
var file = require('./file.js');
var path = require('path');

const garbage = (input, index) => {
    if (input[index] != '<') {
        return index;
    }

    index++;
    var count = 0;
    var done = false;
    while (!done) {
        var char = input[index];

        switch(char) {
            case "!":
                index+=2;
                continue;
            case ">":
                done = true;
                index++;
                continue;
        }

        count++;
        index++;
    }
    
    return {
        index: index,
        count: count
    };
}

const group = (input, index, score) => {
    if (input[index] != '{') {
        return index;
    }
    
    index++;
    var nestedScores = 0;
    var count = 1;
    var garbageCount = 0;
    var done = false;
    while (!done) {
        var char = input[index];

        switch(char) {
            case '<':
                var garbageResult = garbage(input, index);
                index = garbageResult.index;
                garbageCount += garbageResult.count;
                continue;
            case '{':
                var groupResult = group(input, index, score + 1);
                index = groupResult.index;
                nestedScores += groupResult.score;
                count += groupResult.count;
                garbageCount += groupResult.garbageCount;
                continue;
            case '}':
                done = true;
                break;
        }

        index++;
    }

    return { 
        index: index,
        score: score + nestedScores,
        count: count,
        garbageCount: garbageCount
    };
}

const part1 = (input) => {
    return group(input, 0, 1).score;
}

const part2 = (input) => {
    return group(input, 0, 1).garbageCount;    
}
    
module.exports =  { garbage, group, part1, part2 }

group('{{{}}}', 0, 1);

// var s = 'b inc 5 if a > 1\r\na inc 1 if b < 5\r\nc dec -10 if a >= 1\r\nc inc -20 if c == 10';
// console.log("-->" + part1(s));

// file.load(path.resolve(__dirname, './day9.txt'), (data) => {
//     var result = part1(data);
//     console.log("DAY9 result", result);
// });

