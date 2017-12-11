require('./string.js');
var file = require('./file.js');
var path = require('path');

const followInDirection = (direction) => {
    switch(direction) {
        case 'n':
            return { x: 0, y: -1 };
        case 's':
            return { x: 0, y: 1 };
        case 'ne':
            return { x: .5, y: -.5 };
        case 'se':
            return { x: .5, y: .5 };
        case 'nw':
            return { x: -.5, y: -.5 };
        case 'sw':
            return { x: -.5, y: .5 };
    }
}

const stepInDirection = ({ x, y }) => {
    if (x < 0 && y < 0) {
        return 'nw';
    }
    if (x < 0 && y > 0) {
        return 'sw';
    }
    if (x == 0 && y < 0) {
        return 'n';
    }
    if (x == 0 && y > 0) {
        return 's';
    }
    if (x > 0 && y < 0) {
        return 'ne';
    }
    if (x > 0 && y > 0) {
        return 'se';
    }
    if (x > 0 && y == 0) {
        return 'ne';
    }
    if (x < 0 && y == 0) {
        return 'nw';
    }
}

const addDirection = (dir1, dir2) => ({ x: dir1.x + dir2.x, y: dir1.y + dir2.y });
const subDirection = (dir1, dir2) => ({ x: dir1.x - dir2.x, y: dir1.y - dir2.y });
const equalDirection = (dir1, dir2) => dir1.x == dir2.x && dir1.y == dir2.y;
const distDirection = (dir) => Math.sqrt((dir.x * dir.x) + (dir.y * dir.y));

const findTarget = (input) => input.reduce((accumulator, step, index, array) => {
    var position = addDirection(accumulator, followInDirection(step));        
    var further = distDirection(position) > distDirection({ x:accumulator.x, y: accumulator.y });
    return {
        x: position.x,
        y: position.y,
        maxX : further ? position.x : accumulator.maxX,
        maxY : further ? position.y : accumulator.maxY
    }    
}, { x: 0, y: 0, maxX: 0, maxY: 0 });

const stepsToTarget = (target) => {
    var steps = 0;
    var position = { x: 0, y: 0 };
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
    return stepsToTarget({ x: target.maxX, y: target.maxY });
}
    
module.exports =  { part1, part2 }

file.load(path.resolve(__dirname, './day11.txt'), (data) => {
    var result = part2(data);
    console.log("day11 result", result);
});
