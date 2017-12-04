var chai = require('chai');
var expect = chai.expect;
var day4 = require('../day4.js');
var file = require('../file.js');
var path = require('path');

describe('Day 4', () => {

    it('Part 1 [aa bb cc dd ee]', () => {
        var result = day4.part1('aa bb cc dd ee');
        expect(result).to.equal(1);
    });

    it('Part 1 [aa bb cc dd aa]', () => {
        var result = day4.part1('aa bb cc dd aa');
        expect(result).to.equal(0);
    });

    it('Part 1 [aa bb cc dd aaa]', () => {
        var result = day4.part1('aa bb cc dd aaa');
        expect(result).to.equal(1);
    });

    it('Part 1', function(done) { 
        file.load(path.resolve(__dirname, '../day4.txt'), (data) => {
            var result = day4.part1(data);
            console.log("DAY4 result", result);
            expect(result).to.equals(451).satisfy(done());
        });
    });
    
    it('Part 2 [abcde fghij]', () => {
        var result = day4.part2('abcde fghij');
        expect(result).to.equal(1);
    });

    it('Part 2 [abcde xyz ecdab]', () => {
        var result = day4.part2('abcde xyz ecdab');
        expect(result).to.equal(0);
    });

    it('Part 2 [a ab abc abd abf abj]', () => {
        var result = day4.part2('a ab abc abd abf abj');
        expect(result).to.equal(1);
    });

    it('Part 2 [iiii oiii ooii oooi oooo]', () => {
        var result = day4.part2('iiii oiii ooii oooi oooo');
        expect(result).to.equal(1);
    });

    it('Part 2 [oiii ioii iioi iiio]', () => {
        var result = day4.part2('oiii ioii iioi iiio');
        expect(result).to.equal(0);
    });

    it('Part 2', function(done) { 
        file.load(path.resolve(__dirname, '../day4.txt'), (data) => {
            var result = day4.part2(data);
            console.log("DAY4 result", result);
            expect(result).to.equals(223).satisfy(done());
        });
    });
});