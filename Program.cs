// See https://aka.ms/new-console-template for more information

// given S = "nice" and T = "niece", the function should return "INSERT e";

using BLISCORE.Test;

var solution = new Solution();

var res = solution.solution("nice", "niece");

var result = res == "INSERT e";

//given S = "form" and T = 'from', the function should return "SWAP o r";

var res1 = solution.solution("form", "from");

var result1 = res1 == "SWAP o r";

//given S = "test" and T = 'tent', the function  should return "REPLACE s n";

var res2 = solution.solution("test", "tent");

var result2 = res2 == "REPLACE s n";