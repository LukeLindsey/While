// Implementation file for parser generated by fsyacc
module Parser
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open Microsoft.FSharp.Text.Lexing
open Microsoft.FSharp.Text.Parsing.ParseHelpers
# 1 "..\..\Parser.fsy"

open While.AST
open Microsoft.FSharp.Text.Lexing

exception SyntaxError of string

let parse_error msg =
    raise (SyntaxError(msg))

# 16 "..\..\Parser.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | EOF
  | IDENT of (string)
  | INT of (int)
  | DO
  | WHILE
  | ELSE
  | THEN
  | IF
  | SEMICOLON
  | SKIP
  | COLONEQUALS
  | AND
  | NOT
  | LESSTHANEQUALS
  | EQUALS
  | FALSE
  | TRUE
  | RPAREN
  | LPAREN
  | TIMES
  | MINUS
  | PLUS
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_IDENT
    | TOKEN_INT
    | TOKEN_DO
    | TOKEN_WHILE
    | TOKEN_ELSE
    | TOKEN_THEN
    | TOKEN_IF
    | TOKEN_SEMICOLON
    | TOKEN_SKIP
    | TOKEN_COLONEQUALS
    | TOKEN_AND
    | TOKEN_NOT
    | TOKEN_LESSTHANEQUALS
    | TOKEN_EQUALS
    | TOKEN_FALSE
    | TOKEN_TRUE
    | TOKEN_RPAREN
    | TOKEN_LPAREN
    | TOKEN_TIMES
    | TOKEN_MINUS
    | TOKEN_PLUS
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startParseStm
    | NONTERM_ParseStm
    | NONTERM_seq
    | NONTERM_stm
    | NONTERM_aexp
    | NONTERM_term
    | NONTERM_factor
    | NONTERM_bexp
    | NONTERM_bterm
    | NONTERM_bprimary

// This function maps tokens to integers indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | IDENT _ -> 1 
  | INT _ -> 2 
  | DO  -> 3 
  | WHILE  -> 4 
  | ELSE  -> 5 
  | THEN  -> 6 
  | IF  -> 7 
  | SEMICOLON  -> 8 
  | SKIP  -> 9 
  | COLONEQUALS  -> 10 
  | AND  -> 11 
  | NOT  -> 12 
  | LESSTHANEQUALS  -> 13 
  | EQUALS  -> 14 
  | FALSE  -> 15 
  | TRUE  -> 16 
  | RPAREN  -> 17 
  | LPAREN  -> 18 
  | TIMES  -> 19 
  | MINUS  -> 20 
  | PLUS  -> 21 

// This function maps integers indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_IDENT 
  | 2 -> TOKEN_INT 
  | 3 -> TOKEN_DO 
  | 4 -> TOKEN_WHILE 
  | 5 -> TOKEN_ELSE 
  | 6 -> TOKEN_THEN 
  | 7 -> TOKEN_IF 
  | 8 -> TOKEN_SEMICOLON 
  | 9 -> TOKEN_SKIP 
  | 10 -> TOKEN_COLONEQUALS 
  | 11 -> TOKEN_AND 
  | 12 -> TOKEN_NOT 
  | 13 -> TOKEN_LESSTHANEQUALS 
  | 14 -> TOKEN_EQUALS 
  | 15 -> TOKEN_FALSE 
  | 16 -> TOKEN_TRUE 
  | 17 -> TOKEN_RPAREN 
  | 18 -> TOKEN_LPAREN 
  | 19 -> TOKEN_TIMES 
  | 20 -> TOKEN_MINUS 
  | 21 -> TOKEN_PLUS 
  | 24 -> TOKEN_end_of_input
  | 22 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startParseStm 
    | 1 -> NONTERM_ParseStm 
    | 2 -> NONTERM_seq 
    | 3 -> NONTERM_seq 
    | 4 -> NONTERM_stm 
    | 5 -> NONTERM_stm 
    | 6 -> NONTERM_stm 
    | 7 -> NONTERM_stm 
    | 8 -> NONTERM_stm 
    | 9 -> NONTERM_aexp 
    | 10 -> NONTERM_aexp 
    | 11 -> NONTERM_aexp 
    | 12 -> NONTERM_term 
    | 13 -> NONTERM_term 
    | 14 -> NONTERM_factor 
    | 15 -> NONTERM_factor 
    | 16 -> NONTERM_factor 
    | 17 -> NONTERM_bexp 
    | 18 -> NONTERM_bexp 
    | 19 -> NONTERM_bterm 
    | 20 -> NONTERM_bterm 
    | 21 -> NONTERM_bterm 
    | 22 -> NONTERM_bprimary 
    | 23 -> NONTERM_bprimary 
    | 24 -> NONTERM_bprimary 
    | 25 -> NONTERM_bprimary 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 24 
let _fsyacc_tagOfErrorTerminal = 22

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | IDENT _ -> "IDENT" 
  | INT _ -> "INT" 
  | DO  -> "DO" 
  | WHILE  -> "WHILE" 
  | ELSE  -> "ELSE" 
  | THEN  -> "THEN" 
  | IF  -> "IF" 
  | SEMICOLON  -> "SEMICOLON" 
  | SKIP  -> "SKIP" 
  | COLONEQUALS  -> "COLONEQUALS" 
  | AND  -> "AND" 
  | NOT  -> "NOT" 
  | LESSTHANEQUALS  -> "LESSTHANEQUALS" 
  | EQUALS  -> "EQUALS" 
  | FALSE  -> "FALSE" 
  | TRUE  -> "TRUE" 
  | RPAREN  -> "RPAREN" 
  | LPAREN  -> "LPAREN" 
  | TIMES  -> "TIMES" 
  | MINUS  -> "MINUS" 
  | PLUS  -> "PLUS" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | IDENT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | INT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | DO  -> (null : System.Object) 
  | WHILE  -> (null : System.Object) 
  | ELSE  -> (null : System.Object) 
  | THEN  -> (null : System.Object) 
  | IF  -> (null : System.Object) 
  | SEMICOLON  -> (null : System.Object) 
  | SKIP  -> (null : System.Object) 
  | COLONEQUALS  -> (null : System.Object) 
  | AND  -> (null : System.Object) 
  | NOT  -> (null : System.Object) 
  | LESSTHANEQUALS  -> (null : System.Object) 
  | EQUALS  -> (null : System.Object) 
  | FALSE  -> (null : System.Object) 
  | TRUE  -> (null : System.Object) 
  | RPAREN  -> (null : System.Object) 
  | LPAREN  -> (null : System.Object) 
  | TIMES  -> (null : System.Object) 
  | MINUS  -> (null : System.Object) 
  | PLUS  -> (null : System.Object) 
let _fsyacc_gotos = [| 0us; 65535us; 1us; 65535us; 0us; 1us; 2us; 65535us; 0us; 2us; 22us; 4us; 6us; 65535us; 0us; 7us; 5us; 6us; 14us; 15us; 16us; 17us; 20us; 21us; 22us; 7us; 9us; 65535us; 9us; 10us; 12us; 26us; 18us; 26us; 39us; 24us; 40us; 25us; 43us; 26us; 46us; 27us; 47us; 28us; 53us; 26us; 11us; 65535us; 9us; 33us; 12us; 33us; 18us; 33us; 29us; 30us; 31us; 32us; 39us; 33us; 40us; 33us; 43us; 33us; 46us; 33us; 47us; 33us; 53us; 33us; 12us; 65535us; 9us; 36us; 12us; 36us; 18us; 36us; 29us; 36us; 31us; 36us; 34us; 35us; 39us; 36us; 40us; 36us; 43us; 36us; 46us; 36us; 47us; 36us; 53us; 36us; 4us; 65535us; 12us; 13us; 18us; 19us; 40us; 42us; 53us; 42us; 5us; 65535us; 12us; 45us; 18us; 45us; 40us; 45us; 43us; 44us; 53us; 45us; 6us; 65535us; 12us; 48us; 18us; 48us; 40us; 48us; 43us; 48us; 49us; 50us; 53us; 48us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; 3us; 6us; 13us; 23us; 35us; 48us; 53us; 59us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 1us; 0us; 2us; 1us; 2us; 1us; 1us; 2us; 2us; 8us; 1us; 2us; 1us; 2us; 1us; 3us; 1us; 4us; 1us; 4us; 3us; 4us; 9us; 10us; 1us; 5us; 1us; 6us; 2us; 6us; 17us; 1us; 6us; 1us; 6us; 1us; 6us; 1us; 6us; 1us; 7us; 2us; 7us; 17us; 1us; 7us; 1us; 7us; 1us; 8us; 1us; 8us; 3us; 9us; 10us; 16us; 5us; 9us; 10us; 16us; 19us; 20us; 4us; 9us; 10us; 19us; 20us; 3us; 9us; 10us; 19us; 3us; 9us; 10us; 20us; 1us; 9us; 2us; 9us; 12us; 1us; 10us; 2us; 10us; 12us; 2us; 11us; 12us; 1us; 12us; 1us; 12us; 1us; 13us; 1us; 14us; 1us; 15us; 1us; 16us; 2us; 16us; 25us; 1us; 16us; 2us; 17us; 25us; 1us; 17us; 1us; 17us; 1us; 18us; 1us; 19us; 1us; 20us; 1us; 21us; 1us; 22us; 1us; 22us; 1us; 23us; 1us; 24us; 1us; 25us; 1us; 25us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; 4us; 7us; 9us; 12us; 14us; 16us; 18us; 20us; 22us; 26us; 28us; 30us; 33us; 35us; 37us; 39us; 41us; 43us; 46us; 48us; 50us; 52us; 54us; 58us; 64us; 69us; 73us; 77us; 79us; 82us; 84us; 87us; 90us; 92us; 94us; 96us; 98us; 100us; 102us; 105us; 107us; 110us; 112us; 114us; 116us; 118us; 120us; 122us; 124us; 126us; 128us; 130us; 132us; |]
let _fsyacc_action_rows = 55
let _fsyacc_actionTableElements = [|5us; 32768us; 1us; 8us; 4us; 18us; 7us; 12us; 9us; 11us; 18us; 22us; 0us; 49152us; 2us; 32768us; 0us; 3us; 8us; 5us; 0us; 16385us; 2us; 32768us; 8us; 5us; 17us; 23us; 5us; 32768us; 1us; 8us; 4us; 18us; 7us; 12us; 9us; 11us; 18us; 22us; 0us; 16386us; 0us; 16387us; 1us; 32768us; 10us; 9us; 3us; 32768us; 1us; 38us; 2us; 37us; 18us; 39us; 2us; 16388us; 20us; 31us; 21us; 29us; 0us; 16389us; 6us; 32768us; 1us; 38us; 2us; 37us; 12us; 49us; 15us; 52us; 16us; 51us; 18us; 40us; 2us; 32768us; 6us; 14us; 11us; 43us; 5us; 32768us; 1us; 8us; 4us; 18us; 7us; 12us; 9us; 11us; 18us; 22us; 1us; 32768us; 5us; 16us; 5us; 32768us; 1us; 8us; 4us; 18us; 7us; 12us; 9us; 11us; 18us; 22us; 0us; 16390us; 6us; 32768us; 1us; 38us; 2us; 37us; 12us; 49us; 15us; 52us; 16us; 51us; 18us; 40us; 2us; 32768us; 3us; 20us; 11us; 43us; 5us; 32768us; 1us; 8us; 4us; 18us; 7us; 12us; 9us; 11us; 18us; 22us; 0us; 16391us; 5us; 32768us; 1us; 8us; 4us; 18us; 7us; 12us; 9us; 11us; 18us; 22us; 0us; 16392us; 3us; 32768us; 17us; 41us; 20us; 31us; 21us; 29us; 5us; 32768us; 13us; 47us; 14us; 46us; 17us; 41us; 20us; 31us; 21us; 29us; 4us; 32768us; 13us; 47us; 14us; 46us; 20us; 31us; 21us; 29us; 2us; 16403us; 20us; 31us; 21us; 29us; 2us; 16404us; 20us; 31us; 21us; 29us; 3us; 32768us; 1us; 38us; 2us; 37us; 18us; 39us; 1us; 16393us; 19us; 34us; 3us; 32768us; 1us; 38us; 2us; 37us; 18us; 39us; 1us; 16394us; 19us; 34us; 1us; 16395us; 19us; 34us; 3us; 32768us; 1us; 38us; 2us; 37us; 18us; 39us; 0us; 16396us; 0us; 16397us; 0us; 16398us; 0us; 16399us; 3us; 32768us; 1us; 38us; 2us; 37us; 18us; 39us; 6us; 32768us; 1us; 38us; 2us; 37us; 12us; 49us; 15us; 52us; 16us; 51us; 18us; 40us; 0us; 16400us; 2us; 32768us; 11us; 43us; 17us; 54us; 6us; 32768us; 1us; 38us; 2us; 37us; 12us; 49us; 15us; 52us; 16us; 51us; 18us; 40us; 0us; 16401us; 0us; 16402us; 3us; 32768us; 1us; 38us; 2us; 37us; 18us; 39us; 3us; 32768us; 1us; 38us; 2us; 37us; 18us; 39us; 0us; 16405us; 4us; 32768us; 12us; 49us; 15us; 52us; 16us; 51us; 18us; 53us; 0us; 16406us; 0us; 16407us; 0us; 16408us; 6us; 32768us; 1us; 38us; 2us; 37us; 12us; 49us; 15us; 52us; 16us; 51us; 18us; 40us; 0us; 16409us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 6us; 7us; 10us; 11us; 14us; 20us; 21us; 22us; 24us; 28us; 31us; 32us; 39us; 42us; 48us; 50us; 56us; 57us; 64us; 67us; 73us; 74us; 80us; 81us; 85us; 91us; 96us; 99us; 102us; 106us; 108us; 112us; 114us; 116us; 120us; 121us; 122us; 123us; 124us; 128us; 135us; 136us; 139us; 146us; 147us; 148us; 152us; 156us; 157us; 162us; 163us; 164us; 165us; 172us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 2us; 3us; 1us; 3us; 1us; 6us; 4us; 3us; 3us; 3us; 1us; 3us; 1us; 1us; 1us; 3us; 3us; 1us; 3us; 3us; 1us; 2us; 1us; 1us; 3us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; 2us; 2us; 3us; 3us; 3us; 3us; 3us; 4us; 4us; 4us; 5us; 5us; 6us; 6us; 6us; 7us; 7us; 8us; 8us; 8us; 9us; 9us; 9us; 9us; |]
let _fsyacc_immediateActions = [|65535us; 49152us; 65535us; 16385us; 65535us; 65535us; 16386us; 16387us; 65535us; 65535us; 65535us; 16389us; 65535us; 65535us; 65535us; 65535us; 65535us; 16390us; 65535us; 65535us; 65535us; 16391us; 65535us; 16392us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 16396us; 16397us; 16398us; 16399us; 65535us; 65535us; 16400us; 65535us; 65535us; 16401us; 16402us; 65535us; 65535us; 16405us; 65535us; 16406us; 16407us; 16408us; 65535us; 16409us; |]
let _fsyacc_reductions ()  =    [| 
# 231 "..\..\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Stm)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (Microsoft.FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : '_startParseStm));
# 240 "..\..\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'seq)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 44 "..\..\Parser.fsy"
                                                           _1 
                   )
# 44 "..\..\Parser.fsy"
                 : Stm));
# 251 "..\..\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'seq)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'stm)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 46 "..\..\Parser.fsy"
                                                           Seq(_1, _3) 
                   )
# 46 "..\..\Parser.fsy"
                 : 'seq));
# 263 "..\..\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'stm)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 47 "..\..\Parser.fsy"
                                                           _1 
                   )
# 47 "..\..\Parser.fsy"
                 : 'seq));
# 274 "..\..\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'aexp)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 49 "..\..\Parser.fsy"
                                                           Assign(_1, _3) 
                   )
# 49 "..\..\Parser.fsy"
                 : 'stm));
# 286 "..\..\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 50 "..\..\Parser.fsy"
                                                           Skip 
                   )
# 50 "..\..\Parser.fsy"
                 : 'stm));
# 296 "..\..\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'bexp)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : 'stm)) in
            let _6 = (let data = parseState.GetInput(6) in (Microsoft.FSharp.Core.Operators.unbox data : 'stm)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 51 "..\..\Parser.fsy"
                                                           IfElse(_2, _4, _6) 
                   )
# 51 "..\..\Parser.fsy"
                 : 'stm));
# 309 "..\..\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'bexp)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : 'stm)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 52 "..\..\Parser.fsy"
                                                           While(_2, _4) 
                   )
# 52 "..\..\Parser.fsy"
                 : 'stm));
# 321 "..\..\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'seq)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 53 "..\..\Parser.fsy"
                                                           _2 
                   )
# 53 "..\..\Parser.fsy"
                 : 'stm));
# 332 "..\..\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'aexp)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'term)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 55 "..\..\Parser.fsy"
                                                           Add(_1, _3) 
                   )
# 55 "..\..\Parser.fsy"
                 : 'aexp));
# 344 "..\..\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'aexp)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'term)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 56 "..\..\Parser.fsy"
                                                           Sub(_1, _3) 
                   )
# 56 "..\..\Parser.fsy"
                 : 'aexp));
# 356 "..\..\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'term)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 57 "..\..\Parser.fsy"
                                                           _1 
                   )
# 57 "..\..\Parser.fsy"
                 : 'aexp));
# 367 "..\..\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'term)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'factor)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 59 "..\..\Parser.fsy"
                                                           Mul(_1, _3) 
                   )
# 59 "..\..\Parser.fsy"
                 : 'term));
# 379 "..\..\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'factor)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 60 "..\..\Parser.fsy"
                                                           _1 
                   )
# 60 "..\..\Parser.fsy"
                 : 'term));
# 390 "..\..\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 62 "..\..\Parser.fsy"
                                                           Int(_1) 
                   )
# 62 "..\..\Parser.fsy"
                 : 'factor));
# 401 "..\..\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 63 "..\..\Parser.fsy"
                                                           Var(_1) 
                   )
# 63 "..\..\Parser.fsy"
                 : 'factor));
# 412 "..\..\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'aexp)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 64 "..\..\Parser.fsy"
                                                           _2 
                   )
# 64 "..\..\Parser.fsy"
                 : 'factor));
# 423 "..\..\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'bexp)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'bterm)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 66 "..\..\Parser.fsy"
                                                           And(_1, _3) 
                   )
# 66 "..\..\Parser.fsy"
                 : 'bexp));
# 435 "..\..\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'bterm)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 67 "..\..\Parser.fsy"
                                                           _1 
                   )
# 67 "..\..\Parser.fsy"
                 : 'bexp));
# 446 "..\..\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'aexp)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'aexp)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 69 "..\..\Parser.fsy"
                                                           Eq(_1, _3) 
                   )
# 69 "..\..\Parser.fsy"
                 : 'bterm));
# 458 "..\..\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'aexp)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'aexp)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 70 "..\..\Parser.fsy"
                                                           Lte(_1, _3) 
                   )
# 70 "..\..\Parser.fsy"
                 : 'bterm));
# 470 "..\..\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'bprimary)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 71 "..\..\Parser.fsy"
                                                           _1 
                   )
# 71 "..\..\Parser.fsy"
                 : 'bterm));
# 481 "..\..\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'bprimary)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 73 "..\..\Parser.fsy"
                                                           Not(_2) 
                   )
# 73 "..\..\Parser.fsy"
                 : 'bprimary));
# 492 "..\..\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 74 "..\..\Parser.fsy"
                                                           True 
                   )
# 74 "..\..\Parser.fsy"
                 : 'bprimary));
# 502 "..\..\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 75 "..\..\Parser.fsy"
                                                           False 
                   )
# 75 "..\..\Parser.fsy"
                 : 'bprimary));
# 512 "..\..\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'bexp)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 76 "..\..\Parser.fsy"
                                                           _2 
                   )
# 76 "..\..\Parser.fsy"
                 : 'bprimary));
|]
# 524 "..\..\Parser.fs"
let tables () : Microsoft.FSharp.Text.Parsing.Tables<_> = 
  { reductions= _fsyacc_reductions ();
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:Microsoft.FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 25;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = (tables ()).Interpret(lexer, lexbuf, startState)
let ParseStm lexer lexbuf : Stm =
    Microsoft.FSharp.Core.Operators.unbox ((tables ()).Interpret(lexer, lexbuf, 0))
