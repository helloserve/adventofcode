function command(input) {
    input = input.trim();
    console.log("command " + input);    
    
    var dir = input[0];
    var steps = input.substring(1, 999) * 1;
    return steps;
}

function move(input) {
    var commands = input.split(",");
    commands.map(command);
}

function main() {
    console.log("hello word");
}

function test() {
    console.log(move("L1") === 1);
    console.log(move("L2") === 2);
    console.log(move("L1, R1") === 2);
}

test();
main();