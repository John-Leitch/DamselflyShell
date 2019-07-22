using global::Components.Aphid.Parser;
using global::Components.Aphid.Interpreter;

namespace Damselfly.Components.Input {
    
    
    public partial class KeyboardAutomation {
        
        private static TypeDelegate _Type;
        
        public static TypeDelegate Type {
            get {
                if ((KeyboardAutomation._Type == null)) {
                    new AphidInterpreter().Interpret(AphidCompilerResources.ByteCode_360bdcb5815c182907691e1bb2593d82());
                }
                return KeyboardAutomation._Type;
            }
            set {
                KeyboardAutomation._Type = value;
            }
        }
        
        public delegate void TypeDelegate(string text);
    }
}


            namespace Damselfly.Components.Input
            {
                /* Test */
                using global::Components.Aphid.Lexer;
                using global::Components.Aphid.Parser;
                using System;
                using System.Collections.Generic;
            
                public static partial class AphidCompilerResources
                {
                    
                    /*fmt*/

                    public static List<AphidExpression> ByteCode_360bdcb5815c182907691e1bb2593d82() =>
                        ByteCode_360bdcb5815c182907691e1bb2593d82Lazy.Value;

                    private static readonly List<AphidExpression> _empty = new List<AphidExpression>();                    

                    private static System.Lazy<List<AphidExpression>> ByteCode_360bdcb5815c182907691e1bb2593d82Lazy =>
                        new System.Lazy<List<AphidExpression>>(() =>
                            new List<AphidExpression>
{
    new LoadScriptExpression(
        new StringExpression(
            "'Core/Operators'"
        )
    ),
    new LoadScriptExpression(
        new StringExpression(
            "'Automation/Keyboard'"
        )
    ),
    new UnaryOperatorExpression(
        AphidTokenType.usingKeyword,
        new BinaryOperatorExpression(
            new BinaryOperatorExpression(
                new IdentifierExpression(
                    "Damselfly",
                    _IdentifierExpressions
                ),
                AphidTokenType.MemberOperator,
                new IdentifierExpression(
                    "Components",
                    _IdentifierExpressions
                )
            ),
            AphidTokenType.MemberOperator,
            new IdentifierExpression(
                "Input",
                _IdentifierExpressions
            )
        ),
        false
    ),
    new UnaryOperatorExpression(
        AphidTokenType.usingKeyword,
        new BinaryOperatorExpression(
            new IdentifierExpression(
                "System",
                _IdentifierExpressions
            ),
            AphidTokenType.MemberOperator,
            new IdentifierExpression(
                "Test",
                _IdentifierExpressions
            )
        ),
        false
    ),
    new BinaryOperatorExpression(
        new BinaryOperatorExpression(
            new IdentifierExpression(
                "KeyboardAutomation",
                new List<IdentifierExpression>
                {
                    new IdentifierExpression(
                        "export",
                        _IdentifierExpressions
                    ),
                }
            ),
            AphidTokenType.MemberOperator,
            new IdentifierExpression(
                "Type",
                _IdentifierExpressions
            )
        ),
        AphidTokenType.AssignmentOperator,
        new FunctionExpression(
            new List<AphidExpression>
            {
                new IdentifierExpression(
                    "text",
                    new List<IdentifierExpression>
                    {
                        new IdentifierExpression(
                            "string",
                            _IdentifierExpressions
                        ),
                    }
                ),
            },
            new List<AphidExpression>
            {
                new UnaryOperatorExpression(
                    AphidTokenType.retKeyword,
                    new BinaryOperatorExpression(
                        new IdentifierExpression(
                            "text",
                            _IdentifierExpressions
                        ),
                        AphidTokenType.PipelineOperator,
                        new BinaryOperatorExpression(
                            new IdentifierExpression(
                                "keyboard",
                                _IdentifierExpressions
                            ),
                            AphidTokenType.MemberOperator,
                            new IdentifierExpression(
                                "type",
                                _IdentifierExpressions
                            )
                        )
                    ),
                    false
                ),
            }
        )
    ),
}

                        );

                    
                        private static readonly List<IdentifierExpression> _IdentifierExpressions = new List<IdentifierExpression>();
                    

                    
                    
                
                }
            }
            

