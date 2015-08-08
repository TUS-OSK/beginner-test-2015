// 問５

/*
表示されるものは理由をつけてここに述べよ


*/

// 以下のコードにつけたせ

function fraction(child, mother) {
    // ①
    return {
        child: child,
        mother: mother,
        plus: function (other) { return fraction(other.child*this.mother + this.child*other.mother, this.mother*other.mother); },
        minus: function (other) { return this.plus(other.flipSign()); },
        flipSign: function () { return fraction(-child, mother); }
    };
}
function printFraction(frac) {
    console.log(frac.child + " / " + frac.mother);
}

var a = fraction(1, 2);
var b = fraction(3, 4);
printFraction(a.minus(b));