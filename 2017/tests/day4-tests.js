var chai = require('chai');
var expect = chai.expect;
var Day4 = require('../day4.js');
var path = require('path');

describe('Day 4', () => {

    it('Part 1 [aa bb cc dd ee]', () => {
        var day4 = new Day4();
        var result = day4.part1('aa bb cc dd ee');
        expect(result).to.equal(1);
    });

    it('Part 1 [aa bb cc dd aa]', () => {
        var day4 = new Day4();
        var result = day4.part1('aa bb cc dd aa');
        expect(result).to.equal(0);
    });

    it('Part 1 [aa bb cc dd aaa]', () => {
        var day4 = new Day4();
        var result = day4.part1('aa bb cc dd aaa');
        expect(result).to.equal(1);
    });

    it('Part 1', function() { 
        var day4 = new Day4();
        var result = day4.part1File(path.resolve(__dirname, '../day4.txt'), (data) => {
            console.log("DAY4 result", data);
            expect(data).to.equals(451);
        });
    });
    
    it('Part 2 [abcde fghij]', () => {
        var day4 = new Day4();
        var result = day4.part2('abcde fghij');
        expect(result).to.equal(1);
    });

    it('Part 2 [abcde xyz ecdab]', () => {
        var day4 = new Day4();
        var result = day4.part2('abcde xyz ecdab');
        expect(result).to.equal(0);
    });

    it('Part 2 [a ab abc abd abf abj]', () => {
        var day4 = new Day4();
        var result = day4.part2('a ab abc abd abf abj');
        expect(result).to.equal(1);
    });

    it('Part 2 [iiii oiii ooii oooi oooo]', () => {
        var day4 = new Day4();
        var result = day4.part2('iiii oiii ooii oooi oooo');
        expect(result).to.equal(1);
    });

    it('Part 2 [oiii ioii iioi iiio]', () => {
        var day4 = new Day4();
        var result = day4.part2('oiii ioii iioi iiio');
        expect(result).to.equal(0);
    });

    it('Part 2', function() { 
        var day4 = new Day4();
        var result = day4.part2File(path.resolve(__dirname, '../day4.txt'), (data) => {
            console.log("DAY4 result", data);
            expect(data).to.equals(223);
        });
    });
});