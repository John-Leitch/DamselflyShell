using global::Components.Aphid.Interpreter;

namespace Damselfly.Components
{


    public partial class KeyboardAutomation {
        
        private static TypeDelegate _Type;
        
        public static TypeDelegate Type {
            get {
                if ((KeyboardAutomation._Type == null)) {
                    new AphidInterpreter().Interpret(AphidCompilerResources.ByteCode_ce09d37a912bda1972f32c816c9a8656());
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

namespace Damselfly.Components
{
    using global::Components.Aphid.Lexer;
    using global::Components.Aphid.Parser;
    using System.Collections.Generic;

    public static partial class AphidCompilerResources
    {
        public static List<AphidExpression> ByteCode_ce09d37a912bda1972f32c816c9a8656()
        {
            return             new List<AphidExpression>
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
                        new IdentifierExpression(
                            "Damselfly",
                            new List<IdentifierExpression>
                            {
                            }
                        ),
                        AphidTokenType.MemberOperator,
                        new IdentifierExpression(
                            "Components",
                            new List<IdentifierExpression>
                            {
                            }
                        )
                    ),
                    false
                ),
                new UnaryOperatorExpression(
                    AphidTokenType.usingKeyword,
                    new BinaryOperatorExpression(
                        new IdentifierExpression(
                            "System",
                            new List<IdentifierExpression>
                            {
                            }
                        ),
                        AphidTokenType.MemberOperator,
                        new IdentifierExpression(
                            "Test",
                            new List<IdentifierExpression>
                            {
                            }
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
                                    new List<IdentifierExpression>
                                    {
                                    }
                                ),
                            }
                        ),
                        AphidTokenType.MemberOperator,
                        new IdentifierExpression(
                            "Type",
                            new List<IdentifierExpression>
                            {
                            }
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
                                        new List<IdentifierExpression>
                                        {
                                        }
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
                                        new List<IdentifierExpression>
                                        {
                                        }
                                    ),
                                    AphidTokenType.PipelineOperator,
                                    new BinaryOperatorExpression(
                                        new IdentifierExpression(
                                            "keyboard",
                                            new List<IdentifierExpression>
                                            {
                                            }
                                        ),
                                        AphidTokenType.MemberOperator,
                                        new IdentifierExpression(
                                            "type",
                                            new List<IdentifierExpression>
                                            {
                                            }
                                        )
                                    )
                                ),
                                false
                            ),
                        }
                    )
                ),
            }
;
        }
    }
}


