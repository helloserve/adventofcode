require('./string.js');
var file = require('./file.js');
var path = require('path');

const followInDirection = (direction) => {
    switch(direction) {
        case 'n':
            return { q: 0, r: -1 };
        case 's':
            return { q: 0, r: 1 };
        case 'ne':
            return { q: 1, r: -1 };
        case 'se':
            return { q: 1, r: 0 };
        case 'nw':
            return { q: -1, r: 0 };
        case 'sw':
            return { q: -1, r: 1 };
    }
}

const stepInDirection = ({ q, r }) => {
    if (q < 0 && r <= 0) {
        return 'nw';
    }
    if (q < 0 && r > 0) {
        return 'sw';
    }
    if (q == 0 && r < 0) {
        return 'n';
    }
    if (q == 0 && r > 0) {
        return 's';
    }
    if (q > 0 && r < 0) {
        return 'ne';
    }
    if (q > 0 && r >= 0) {
        return 'se';
    }
}

const addDirection = (dir1, dir2) => ({ q: dir1.q + dir2.q, r: dir1.r + dir2.r });
const subDirection = (dir1, dir2) => ({ q: dir1.q - dir2.q, r: dir1.r - dir2.r });
const equalDirection = (dir1, dir2) => dir1.q == dir2.q && dir1.r == dir2.r;
const distDirection = (dir1, dir2) => (Math.abs(dir1.q - dir2.q) + Math.abs(dir1.q + dir1.r - dir2.q - dir2.r) + Math.abs(dir1.r - dir2.r)) / 2;

const findTarget = (input) => input.reduce((accumulator, step, index, array) => {
    var position = addDirection(accumulator, followInDirection(step));        
    var further = distDirection({ q: 0, r: 0}, position) > distDirection({q: 0, r: 0}, { q:accumulator.maxQ, r: accumulator.maxR });
    return {
        q: position.q,
        r: position.r,
        maxQ : further ? position.q : accumulator.maxQ,
        maxR : further ? position.r : accumulator.maxR
    }    
}, { q: 0, r: 0, maxQ: 0, maxR: 0 });

const stepsToTarget = (target) => {
    var steps = 0;
    var position = { q: 0, r: 0 };
    while (!equalDirection(position, target)) {
        var direction = stepInDirection(subDirection(target, position));
        position = addDirection(position, followInDirection(direction));
        steps++;
    }
    return steps;
};

const part1 = (input) => {
    var target = findTarget(input.split(','));
    return stepsToTarget(target);
}

const part2 = (input) => {
    var target = findTarget(input.split(','));
    return stepsToTarget({ q: target.maxQ, r: target.maxR });
}
    
module.exports =  { part1, part2 }

console.log(part1('ne,ne,ne'));
console.log(part1('ne,ne,sw,sw'));
console.log(part1('ne,ne,s,s'));
console.log(part1('se,sw,se,sw,sw'));

file.load(path.resolve(__dirname, './day11.txt'), (data) => {
    var result = part2(data);
    console.log("day11 result", result);
});
