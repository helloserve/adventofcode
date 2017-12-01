var chai = require('chai');
var expect = chai.expect;
var Day1 = require('../day1.js');
var path = require('path');

describe('Day 1', function() {
    it('Part 1 [1122]', function() {
        var day1 = new Day1();
        var result = day1.part1('1122');
        expect(result).to.equal(3);
    });

    it('Part 1 [1111]', function() {
        var day1 = new Day1();
        var result = day1.part1('1111');
        expect(result).to.equal(4);
    });

    it('Part 1 [1234]', function() {
        var day1 = new Day1();
        var result = day1.part1('1234');
        expect(result).to.equal(0);
    });

    it('Part 1 [91212129]', function() {
        var day1 = new Day1();
        var result = day1.part1('91212129');
        expect(result).to.equal(9);
    });

    it('Part 1', function() { 
        var day1 = new Day1();
        var result = day1.part1File(path.resolve(__dirname, '../day1.txt'), (data) => {
            console.log("DAY1 result", data);
            expect(data).to.equals(1228);
        });
    });

    it('Part 2 [1212]', function() {
        var day1 = new Day1();
        var result = day1.part2('1212');
        expect(result).to.equal(6);
    });

    it('Part 2 [1221]', function() {
        var day1 = new Day1();
        var result = day1.part2('1221');
        expect(result).to.equal(0);
    });

    it('Part 2 [123425]', function() {
        var day1 = new Day1();
        var result = day1.part2('123425');
        expect(result).to.equal(4);
    });

    it('Part 2 [123123]', function() {
        var day1 = new Day1();
        var result = day1.part2('123123');
        expect(result).to.equal(12);
    });

    it('Part 2 [12131415]', function() {
        var day1 = new Day1();
        var result = day1.part2('12131415');
        expect(result).to.equal(4);
    });

    it('Part 2', function() { 
        var day1 = new Day1();
        var result = day1.part2File(path.resolve(__dirname, '../day1.txt'), (data) => {
            console.log("DAY1 result", data);
            expect(data).to.equals(1238);
        });
    });

});