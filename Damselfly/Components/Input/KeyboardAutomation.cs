using global::Components.Aphid.Parser;
using global::Components.Aphid.Interpreter;

namespace Damselfly.Components.Input {
    
    
    public partial class KeyboardAutomation {
        
        private static TypeDelegate _Type;
        
        public static TypeDelegate Type {
            get {
                if ((KeyboardAutomation._Type == null)) {
                    new AphidInterpreter().Interpret(AphidCompilerResources.ByteCode_b9336ae45eb340694f1966582e281be6());
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

                    public static List<AphidExpression> ByteCode_b9336ae45eb340694f1966582e281be6() =>
                        ByteCode_b9336ae45eb340694f1966582e281be6Lazy.Value;

                    private static readonly List<AphidExpression> _empty = new List<AphidExpression>();                    

                    private static System.Lazy<List<AphidExpression>> ByteCode_b9336ae45eb340694f1966582e281be6Lazy =>
                        new System.Lazy<List<AphidExpression>>(() =>
                            new List<AphidExpression>
                            {
                                new UnaryOperatorExpression(
                                    AphidTokenType.usingKeyword,
                                    new BinaryOperatorExpression(
                                        new IdentifierExpression(
                                            "System",
                                            _IdentifierExpressions
                                        ),
                                        AphidTokenType.MemberOperator,
                                        new IdentifierExpression(
                                            "IO",
                                            _IdentifierExpressions
                                        )
                                    ),
                                    false
                                ),
                                new UnaryOperatorExpression(
                                    AphidTokenType.usingKeyword,
                                    new BinaryOperatorExpression(
                                        new BinaryOperatorExpression(
                                            new IdentifierExpression(
                                                "System",
                                                _IdentifierExpressions
                                            ),
                                            AphidTokenType.MemberOperator,
                                            new IdentifierExpression(
                                                "Text",
                                                _IdentifierExpressions
                                            )
                                        ),
                                        AphidTokenType.MemberOperator,
                                        new IdentifierExpression(
                                            "RegularExpressions",
                                            _IdentifierExpressions
                                        )
                                    ),
                                    false
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator214,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "fmt",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "args",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new CallExpression(
                                                    new BinaryOperatorExpression(
                                                        new IdentifierExpression(
                                                            "string",
                                                            _IdentifierExpressions
                                                        ),
                                                        AphidTokenType.MemberOperator,
                                                        new IdentifierExpression(
                                                            "Format",
                                                            _IdentifierExpressions
                                                        )
                                                    ),
                                                    new List<AphidExpression>
                                                    {
                                                        new IdentifierExpression(
                                                            "fmt",
                                                            _IdentifierExpressions
                                                        ),
                                                        new IdentifierExpression(
                                                            "args",
                                                            _IdentifierExpressions
                                                        ),
                                                    }
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator216,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "fmt",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "args",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new TernaryOperatorExpression(
                                                    AphidTokenType.ConditionalOperator,
                                                    new UnaryOperatorExpression(
                                                        AphidTokenType.definedKeyword,
                                                        new IdentifierExpression(
                                                            "args",
                                                            _IdentifierExpressions
                                                        ),
                                                        true
                                                    ),
                                                    new BinaryOperatorExpression(
                                                        new IdentifierExpression(
                                                            "fmt",
                                                            _IdentifierExpressions
                                                        ),
                                                        AphidTokenType.CustomOperator214,
                                                        new IdentifierExpression(
                                                            "args",
                                                            _IdentifierExpressions
                                                        )
                                                    ),
                                                    new BinaryOperatorExpression(
                                                        new IdentifierExpression(
                                                            "fmt",
                                                            _IdentifierExpressions
                                                        ),
                                                        AphidTokenType.PipelineOperator,
                                                        new IdentifierExpression(
                                                            "print",
                                                            _IdentifierExpressions
                                                        )
                                                    )
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator313,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "string",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "defaultValue",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new TernaryOperatorExpression(
                                                    AphidTokenType.ConditionalOperator,
                                                    new UnaryOperatorExpression(
                                                        AphidTokenType.NotOperator,
                                                        new CallExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "String",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.MemberOperator,
                                                                new IdentifierExpression(
                                                                    "IsNullOrEmpty",
                                                                    _IdentifierExpressions
                                                                )
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new IdentifierExpression(
                                                                    "string",
                                                                    _IdentifierExpressions
                                                                ),
                                                            }
                                                        ),
                                                        false
                                                    ),
                                                    new IdentifierExpression(
                                                        "string",
                                                        _IdentifierExpressions
                                                    ),
                                                    new IdentifierExpression(
                                                        "defaultValue",
                                                        _IdentifierExpressions
                                                    )
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator317,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "func",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "defaultValue",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new TryExpression(
                                                new List<AphidExpression>
                                                {
                                                    new UnaryOperatorExpression(
                                                        AphidTokenType.retKeyword,
                                                        new CallExpression(
                                                            new IdentifierExpression(
                                                                "func",
                                                                _IdentifierExpressions
                                                            ),
                                                            _AphidExpressions
                                                        ),
                                                        false
                                                    ),
                                                },
                                                null,
                                                new List<AphidExpression>
                                                {
                                                    new UnaryOperatorExpression(
                                                        AphidTokenType.retKeyword,
                                                        new IdentifierExpression(
                                                            "defaultValue",
                                                            _IdentifierExpressions
                                                        ),
                                                        false
                                                    ),
                                                },
                                                null
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator315,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "func",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "defaultValue",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new FunctionExpression(
                                                    _AphidExpressions,
                                                    new List<AphidExpression>
                                                    {
                                                        new TryExpression(
                                                            new List<AphidExpression>
                                                            {
                                                                new UnaryOperatorExpression(
                                                                    AphidTokenType.retKeyword,
                                                                    new CallExpression(
                                                                        new IdentifierExpression(
                                                                            "func",
                                                                            _IdentifierExpressions
                                                                        ),
                                                                        new List<AphidExpression>
                                                                        {
                                                                            new ImplicitArgumentExpression(
                                                                                AphidTokenType.ImplicitArgumentOperator
                                                                            ),
                                                                        }
                                                                    ),
                                                                    false
                                                                ),
                                                            },
                                                            null,
                                                            new List<AphidExpression>
                                                            {
                                                                new UnaryOperatorExpression(
                                                                    AphidTokenType.retKeyword,
                                                                    new IdentifierExpression(
                                                                        "defaultValue",
                                                                        _IdentifierExpressions
                                                                    ),
                                                                    false
                                                                ),
                                                            },
                                                            null
                                                        ),
                                                    }
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator319,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "value",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "defaultValue",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new TernaryOperatorExpression(
                                                    AphidTokenType.ConditionalOperator,
                                                    new BinaryOperatorExpression(
                                                        new IdentifierExpression(
                                                            "value",
                                                            _IdentifierExpressions
                                                        ),
                                                        AphidTokenType.NotEqualOperator,
                                                        _NullExpression
                                                    ),
                                                    new IdentifierExpression(
                                                        "value",
                                                        _IdentifierExpressions
                                                    ),
                                                    new IdentifierExpression(
                                                        "defaultValue",
                                                        _IdentifierExpressions
                                                    )
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator223,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "func",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new BinaryOperatorExpression(
                                                    new IdentifierExpression(
                                                        "func",
                                                        _IdentifierExpressions
                                                    ),
                                                    AphidTokenType.CustomOperator315,
                                                    new BooleanExpression(
                                                        false
                                                    )
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator201,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "source",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "func",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new PatternMatchingExpression(
                                                    new BinaryOperatorExpression(
                                                        new ImplicitArgumentsExpression(
                                                            AphidTokenType.ImplicitArgumentsOperator
                                                        ),
                                                        AphidTokenType.MemberOperator,
                                                        new IdentifierExpression(
                                                            "Count",
                                                            _IdentifierExpressions
                                                        )
                                                    ),
                                                    new List<PatternExpression>
                                                    {
                                                        new PatternExpression(
                                                            new BinaryOperatorExpression(
                                                                new BinaryOperatorExpression(
                                                                    new IdentifierExpression(
                                                                        "source",
                                                                        _IdentifierExpressions
                                                                    ),
                                                                    AphidTokenType.NotEqualOperator,
                                                                    _NullExpression
                                                                ),
                                                                AphidTokenType.AndOperator,
                                                                new CallExpression(
                                                                    new BinaryOperatorExpression(
                                                                        new IdentifierExpression(
                                                                            "Enumerable",
                                                                            _IdentifierExpressions
                                                                        ),
                                                                        AphidTokenType.MemberOperator,
                                                                        new IdentifierExpression(
                                                                            "Any",
                                                                            _IdentifierExpressions
                                                                        )
                                                                    ),
                                                                    new List<AphidExpression>
                                                                    {
                                                                        new IdentifierExpression(
                                                                            "source",
                                                                            _IdentifierExpressions
                                                                        ),
                                                                    }
                                                                )
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new NumberExpression(
                                                                    1
                                                                ),
                                                            }
                                                        ),
                                                        new PatternExpression(
                                                            new TernaryOperatorExpression(
                                                                AphidTokenType.ConditionalOperator,
                                                                new BinaryOperatorExpression(
                                                                    new BinaryOperatorExpression(
                                                                        new IdentifierExpression(
                                                                            "source",
                                                                            _IdentifierExpressions
                                                                        ),
                                                                        AphidTokenType.NotEqualOperator,
                                                                        _NullExpression
                                                                    ),
                                                                    AphidTokenType.AndOperator,
                                                                    new CallExpression(
                                                                        new BinaryOperatorExpression(
                                                                            new IdentifierExpression(
                                                                                "Enumerable",
                                                                                _IdentifierExpressions
                                                                            ),
                                                                            AphidTokenType.MemberOperator,
                                                                            new IdentifierExpression(
                                                                                "Any",
                                                                                _IdentifierExpressions
                                                                            )
                                                                        ),
                                                                        new List<AphidExpression>
                                                                        {
                                                                            new IdentifierExpression(
                                                                                "source",
                                                                                _IdentifierExpressions
                                                                            ),
                                                                        }
                                                                    )
                                                                ),
                                                                new CallExpression(
                                                                    new IdentifierExpression(
                                                                        "func",
                                                                        _IdentifierExpressions
                                                                    ),
                                                                    new List<AphidExpression>
                                                                    {
                                                                        new IdentifierExpression(
                                                                            "source",
                                                                            _IdentifierExpressions
                                                                        ),
                                                                    }
                                                                ),
                                                                _NullExpression
                                                            ),
                                                            _AphidExpressions
                                                        ),
                                                    }
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator102,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "source",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "defaultValue",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new TryExpression(
                                                new List<AphidExpression>
                                                {
                                                    new UnaryOperatorExpression(
                                                        AphidTokenType.retKeyword,
                                                        new UnaryOperatorExpression(
                                                            AphidTokenType.PostfixFirstOperator,
                                                            new IdentifierExpression(
                                                                "source",
                                                                _IdentifierExpressions
                                                            ),
                                                            false
                                                        ),
                                                        false
                                                    ),
                                                },
                                                null,
                                                new List<AphidExpression>
                                                {
                                                    new UnaryOperatorExpression(
                                                        AphidTokenType.retKeyword,
                                                        new IdentifierExpression(
                                                            "defaultValue",
                                                            _IdentifierExpressions
                                                        ),
                                                        false
                                                    ),
                                                },
                                                null
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator223,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "source",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "func",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new TernaryOperatorExpression(
                                                    AphidTokenType.ConditionalOperator,
                                                    new BinaryOperatorExpression(
                                                        new BinaryOperatorExpression(
                                                            new ImplicitArgumentsExpression(
                                                                AphidTokenType.ImplicitArgumentsOperator
                                                            ),
                                                            AphidTokenType.MemberOperator,
                                                            new IdentifierExpression(
                                                                "Count",
                                                                _IdentifierExpressions
                                                            )
                                                        ),
                                                        AphidTokenType.EqualityOperator,
                                                        new NumberExpression(
                                                            2
                                                        )
                                                    ),
                                                    new BinaryOperatorExpression(
                                                        new IdentifierExpression(
                                                            "source",
                                                            _IdentifierExpressions
                                                        ),
                                                        AphidTokenType.WhereOperator,
                                                        new UnaryOperatorExpression(
                                                            AphidTokenType.CustomOperator223,
                                                            new IdentifierExpression(
                                                                "func",
                                                                _IdentifierExpressions
                                                            ),
                                                            false
                                                        )
                                                    ),
                                                    new BinaryOperatorExpression(
                                                        new IdentifierExpression(
                                                            "source",
                                                            _IdentifierExpressions
                                                        ),
                                                        AphidTokenType.CustomOperator315,
                                                        new BooleanExpression(
                                                            false
                                                        )
                                                    )
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator282,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "source",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "func",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new CallExpression(
                                                new IdentifierExpression(
                                                    "func",
                                                    _IdentifierExpressions
                                                ),
                                                new List<AphidExpression>
                                                {
                                                    new IdentifierExpression(
                                                        "source",
                                                        _IdentifierExpressions
                                                    ),
                                                }
                                            ),
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new IdentifierExpression(
                                                    "source",
                                                    _IdentifierExpressions
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator146,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "source",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "delim",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new BinaryOperatorExpression(
                                                    new IdentifierExpression(
                                                        "source",
                                                        _IdentifierExpressions
                                                    ),
                                                    AphidTokenType.AggregateOperator,
                                                    new FunctionExpression(
                                                        new List<AphidExpression>
                                                        {
                                                            new IdentifierExpression(
                                                                "x",
                                                                _IdentifierExpressions
                                                            ),
                                                            new IdentifierExpression(
                                                                "y",
                                                                _IdentifierExpressions
                                                            ),
                                                        },
                                                        new List<AphidExpression>
                                                        {
                                                            new UnaryOperatorExpression(
                                                                AphidTokenType.retKeyword,
                                                                new BinaryOperatorExpression(
                                                                    new BinaryOperatorExpression(
                                                                        new IdentifierExpression(
                                                                            "x",
                                                                            _IdentifierExpressions
                                                                        ),
                                                                        AphidTokenType.AdditionOperator,
                                                                        new IdentifierExpression(
                                                                            "delim",
                                                                            _IdentifierExpressions
                                                                        )
                                                                    ),
                                                                    AphidTokenType.AdditionOperator,
                                                                    new IdentifierExpression(
                                                                        "y",
                                                                        _IdentifierExpressions
                                                                    )
                                                                ),
                                                                false
                                                            ),
                                                        }
                                                    )
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator149,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "source",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "predicate",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new UnaryOperatorExpression(
                                                AphidTokenType.usingKeyword,
                                                new BinaryOperatorExpression(
                                                    new IdentifierExpression(
                                                        "System",
                                                        _IdentifierExpressions
                                                    ),
                                                    AphidTokenType.MemberOperator,
                                                    new IdentifierExpression(
                                                        "Linq",
                                                        _IdentifierExpressions
                                                    )
                                                ),
                                                false
                                            ),
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new BinaryOperatorExpression(
                                                    new BinaryOperatorExpression(
                                                        new IdentifierExpression(
                                                            "source",
                                                            _IdentifierExpressions
                                                        ),
                                                        AphidTokenType.WhereOperator,
                                                        new IdentifierExpression(
                                                            "predicate",
                                                            _IdentifierExpressions
                                                        )
                                                    ),
                                                    AphidTokenType.PipelineOperator,
                                                    new BinaryOperatorExpression(
                                                        new IdentifierExpression(
                                                            "Enumerable",
                                                            _IdentifierExpressions
                                                        ),
                                                        AphidTokenType.MemberOperator,
                                                        new IdentifierExpression(
                                                            "Single",
                                                            _IdentifierExpressions
                                                        )
                                                    )
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator142,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "source",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "predicate",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new UnaryOperatorExpression(
                                                AphidTokenType.usingKeyword,
                                                new BinaryOperatorExpression(
                                                    new IdentifierExpression(
                                                        "System",
                                                        _IdentifierExpressions
                                                    ),
                                                    AphidTokenType.MemberOperator,
                                                    new IdentifierExpression(
                                                        "Linq",
                                                        _IdentifierExpressions
                                                    )
                                                ),
                                                false
                                            ),
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new BinaryOperatorExpression(
                                                    new BinaryOperatorExpression(
                                                        new IdentifierExpression(
                                                            "source",
                                                            _IdentifierExpressions
                                                        ),
                                                        AphidTokenType.WhereOperator,
                                                        new IdentifierExpression(
                                                            "predicate",
                                                            _IdentifierExpressions
                                                        )
                                                    ),
                                                    AphidTokenType.PipelineOperator,
                                                    new BinaryOperatorExpression(
                                                        new BinaryOperatorExpression(
                                                            new IdentifierExpression(
                                                                "Enumerable",
                                                                _IdentifierExpressions
                                                            ),
                                                            AphidTokenType.MemberOperator,
                                                            new IdentifierExpression(
                                                                "Any",
                                                                _IdentifierExpressions
                                                            )
                                                        ),
                                                        AphidTokenType.CompositionOperator,
                                                        new FunctionExpression(
                                                            new List<AphidExpression>
                                                            {
                                                                new IdentifierExpression(
                                                                    "___p_op_0",
                                                                    _IdentifierExpressions
                                                                ),
                                                            },
                                                            new List<AphidExpression>
                                                            {
                                                                new UnaryOperatorExpression(
                                                                    AphidTokenType.retKeyword,
                                                                    new BinaryOperatorExpression(
                                                                        new IdentifierExpression(
                                                                            "___p_op_0",
                                                                            _IdentifierExpressions
                                                                        ),
                                                                        AphidTokenType.EqualityOperator,
                                                                        new BooleanExpression(
                                                                            false
                                                                        )
                                                                    ),
                                                                    false
                                                                ),
                                                            }
                                                        )
                                                    )
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator143,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "source",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "action",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new ForEachExpression(
                                                new IdentifierExpression(
                                                    "source",
                                                    _IdentifierExpressions
                                                ),
                                                new List<AphidExpression>
                                                {
                                                    new CallExpression(
                                                        new IdentifierExpression(
                                                            "action",
                                                            _IdentifierExpressions
                                                        ),
                                                        new List<AphidExpression>
                                                        {
                                                            new ImplicitArgumentExpression(
                                                                AphidTokenType.ImplicitArgumentOperator
                                                            ),
                                                        }
                                                    ),
                                                },
                                                null
                                            ),
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new IdentifierExpression(
                                                    "source",
                                                    _IdentifierExpressions
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator028,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "input",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "pattern",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new CallExpression(
                                                    new BinaryOperatorExpression(
                                                        new IdentifierExpression(
                                                            "Regex",
                                                            _IdentifierExpressions
                                                        ),
                                                        AphidTokenType.MemberOperator,
                                                        new IdentifierExpression(
                                                            "IsMatch",
                                                            _IdentifierExpressions
                                                        )
                                                    ),
                                                    new List<AphidExpression>
                                                    {
                                                        new CallExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "input",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.MemberOperator,
                                                                new IdentifierExpression(
                                                                    "ToString",
                                                                    _IdentifierExpressions
                                                                )
                                                            ),
                                                            _AphidExpressions
                                                        ),
                                                        new CallExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "pattern",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.MemberOperator,
                                                                new IdentifierExpression(
                                                                    "ToString",
                                                                    _IdentifierExpressions
                                                                )
                                                            ),
                                                            _AphidExpressions
                                                        ),
                                                        new IdentifierExpression(
                                                            "defaultRegexOptions",
                                                            _IdentifierExpressions
                                                        ),
                                                    }
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator021,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "input",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "pattern",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new BinaryOperatorExpression(
                                                    new CallExpression(
                                                        new BinaryOperatorExpression(
                                                            new IdentifierExpression(
                                                                "Regex",
                                                                _IdentifierExpressions
                                                            ),
                                                            AphidTokenType.MemberOperator,
                                                            new IdentifierExpression(
                                                                "Matches",
                                                                _IdentifierExpressions
                                                            )
                                                        ),
                                                        new List<AphidExpression>
                                                        {
                                                            new CallExpression(
                                                                new BinaryOperatorExpression(
                                                                    new IdentifierExpression(
                                                                        "input",
                                                                        _IdentifierExpressions
                                                                    ),
                                                                    AphidTokenType.MemberOperator,
                                                                    new IdentifierExpression(
                                                                        "ToString",
                                                                        _IdentifierExpressions
                                                                    )
                                                                ),
                                                                _AphidExpressions
                                                            ),
                                                            new CallExpression(
                                                                new BinaryOperatorExpression(
                                                                    new IdentifierExpression(
                                                                        "pattern",
                                                                        _IdentifierExpressions
                                                                    ),
                                                                    AphidTokenType.MemberOperator,
                                                                    new IdentifierExpression(
                                                                        "ToString",
                                                                        _IdentifierExpressions
                                                                    )
                                                                ),
                                                                _AphidExpressions
                                                            ),
                                                            new IdentifierExpression(
                                                                "defaultRegexOptions",
                                                                _IdentifierExpressions
                                                            ),
                                                        }
                                                    ),
                                                    AphidTokenType.PipelineOperator,
                                                    new FunctionExpression(
                                                        new List<AphidExpression>
                                                        {
                                                            new IdentifierExpression(
                                                                "m",
                                                                _IdentifierExpressions
                                                            ),
                                                        },
                                                        new List<AphidExpression>
                                                        {
                                                            new UnaryOperatorExpression(
                                                                AphidTokenType.retKeyword,
                                                                new BinaryOperatorExpression(
                                                                    new BinaryOperatorExpression(
                                                                        new NumberExpression(
                                                                            0
                                                                        ),
                                                                        AphidTokenType.RangeOperator,
                                                                        new UnaryOperatorExpression(
                                                                            AphidTokenType.PostfixCountOperator,
                                                                            new IdentifierExpression(
                                                                                "m",
                                                                                _IdentifierExpressions
                                                                            ),
                                                                            false
                                                                        )
                                                                    ),
                                                                    AphidTokenType.SelectOperator,
                                                                    new FunctionExpression(
                                                                        _AphidExpressions,
                                                                        new List<AphidExpression>
                                                                        {
                                                                            new UnaryOperatorExpression(
                                                                                AphidTokenType.retKeyword,
                                                                                new ArrayAccessExpression(
                                                                                    new IdentifierExpression(
                                                                                        "m",
                                                                                        _IdentifierExpressions
                                                                                    ),
                                                                                    new List<AphidExpression>
                                                                                    {
                                                                                        new ImplicitArgumentExpression(
                                                                                            AphidTokenType.ImplicitArgumentOperator
                                                                                        ),
                                                                                    }
                                                                                ),
                                                                                false
                                                                            ),
                                                                        }
                                                                    )
                                                                ),
                                                                false
                                                            ),
                                                        }
                                                    )
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator031,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "input",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "replace",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new PatternMatchingExpression(
                                                    new CallExpression(
                                                        new BinaryOperatorExpression(
                                                            new IdentifierExpression(
                                                                "replace",
                                                                _IdentifierExpressions
                                                            ),
                                                            AphidTokenType.MemberOperator,
                                                            new IdentifierExpression(
                                                                "GetType",
                                                                _IdentifierExpressions
                                                            )
                                                        ),
                                                        _AphidExpressions
                                                    ),
                                                    new List<PatternExpression>
                                                    {
                                                        new PatternExpression(
                                                            new CallExpression(
                                                                new BinaryOperatorExpression(
                                                                    new IdentifierExpression(
                                                                        "Regex",
                                                                        _IdentifierExpressions
                                                                    ),
                                                                    AphidTokenType.MemberOperator,
                                                                    new IdentifierExpression(
                                                                        "Replace",
                                                                        _IdentifierExpressions
                                                                    )
                                                                ),
                                                                new List<AphidExpression>
                                                                {
                                                                    new CallExpression(
                                                                        new BinaryOperatorExpression(
                                                                            new IdentifierExpression(
                                                                                "input",
                                                                                _IdentifierExpressions
                                                                            ),
                                                                            AphidTokenType.MemberOperator,
                                                                            new IdentifierExpression(
                                                                                "ToString",
                                                                                _IdentifierExpressions
                                                                            )
                                                                        ),
                                                                        _AphidExpressions
                                                                    ),
                                                                    new IdentifierExpression(
                                                                        "replace",
                                                                        _IdentifierExpressions
                                                                    ),
                                                                    new StringExpression(
                                                                        "''"
                                                                    ),
                                                                    new IdentifierExpression(
                                                                        "defaultRegexOptions",
                                                                        _IdentifierExpressions
                                                                    ),
                                                                }
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new IdentifierExpression(
                                                                    "String",
                                                                    _IdentifierExpressions
                                                                ),
                                                            }
                                                        ),
                                                        new PatternExpression(
                                                            new CallExpression(
                                                                new BinaryOperatorExpression(
                                                                    new IdentifierExpression(
                                                                        "Regex",
                                                                        _IdentifierExpressions
                                                                    ),
                                                                    AphidTokenType.MemberOperator,
                                                                    new IdentifierExpression(
                                                                        "Replace",
                                                                        _IdentifierExpressions
                                                                    )
                                                                ),
                                                                new List<AphidExpression>
                                                                {
                                                                    new CallExpression(
                                                                        new BinaryOperatorExpression(
                                                                            new IdentifierExpression(
                                                                                "input",
                                                                                _IdentifierExpressions
                                                                            ),
                                                                            AphidTokenType.MemberOperator,
                                                                            new IdentifierExpression(
                                                                                "ToString",
                                                                                _IdentifierExpressions
                                                                            )
                                                                        ),
                                                                        _AphidExpressions
                                                                    ),
                                                                    new ArrayAccessExpression(
                                                                        new IdentifierExpression(
                                                                            "replace",
                                                                            _IdentifierExpressions
                                                                        ),
                                                                        new List<AphidExpression>
                                                                        {
                                                                            new NumberExpression(
                                                                                0
                                                                            ),
                                                                        }
                                                                    ),
                                                                    new ArrayAccessExpression(
                                                                        new IdentifierExpression(
                                                                            "replace",
                                                                            _IdentifierExpressions
                                                                        ),
                                                                        new List<AphidExpression>
                                                                        {
                                                                            new NumberExpression(
                                                                                1
                                                                            ),
                                                                        }
                                                                    ),
                                                                    new IdentifierExpression(
                                                                        "defaultRegexOptions",
                                                                        _IdentifierExpressions
                                                                    ),
                                                                }
                                                            ),
                                                            _AphidExpressions
                                                        ),
                                                    }
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator037,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "input",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "pattern",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new BinaryOperatorExpression(
                                                    new IdentifierExpression(
                                                        "input",
                                                        _IdentifierExpressions
                                                    ),
                                                    AphidTokenType.WhereOperator,
                                                    new FunctionExpression(
                                                        _AphidExpressions,
                                                        new List<AphidExpression>
                                                        {
                                                            new UnaryOperatorExpression(
                                                                AphidTokenType.retKeyword,
                                                                new BinaryOperatorExpression(
                                                                    new ImplicitArgumentExpression(
                                                                        AphidTokenType.ImplicitArgumentOperator
                                                                    ),
                                                                    AphidTokenType.CustomOperator028,
                                                                    new IdentifierExpression(
                                                                        "pattern",
                                                                        _IdentifierExpressions
                                                                    )
                                                                ),
                                                                false
                                                            ),
                                                        }
                                                    )
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator035,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "input",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "pattern",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new CallExpression(
                                                    new BinaryOperatorExpression(
                                                        new IdentifierExpression(
                                                            "Enumerable",
                                                            _IdentifierExpressions
                                                        ),
                                                        AphidTokenType.MemberOperator,
                                                        new IdentifierExpression(
                                                            "Single",
                                                            _IdentifierExpressions
                                                        )
                                                    ),
                                                    new List<AphidExpression>
                                                    {
                                                        new BinaryOperatorExpression(
                                                            new IdentifierExpression(
                                                                "input",
                                                                _IdentifierExpressions
                                                            ),
                                                            AphidTokenType.WhereOperator,
                                                            new FunctionExpression(
                                                                _AphidExpressions,
                                                                new List<AphidExpression>
                                                                {
                                                                    new UnaryOperatorExpression(
                                                                        AphidTokenType.retKeyword,
                                                                        new BinaryOperatorExpression(
                                                                            new ImplicitArgumentExpression(
                                                                                AphidTokenType.ImplicitArgumentOperator
                                                                            ),
                                                                            AphidTokenType.CustomOperator028,
                                                                            new IdentifierExpression(
                                                                                "pattern",
                                                                                _IdentifierExpressions
                                                                            )
                                                                        ),
                                                                        false
                                                                    ),
                                                                }
                                                            )
                                                        ),
                                                    }
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator229,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "selector",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "source",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new BinaryOperatorExpression(
                                                    new IdentifierExpression(
                                                        "source",
                                                        _IdentifierExpressions
                                                    ),
                                                    AphidTokenType.SelectOperator,
                                                    new IdentifierExpression(
                                                        "selector",
                                                        _IdentifierExpressions
                                                    )
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator309,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "selector",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "source",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new BinaryOperatorExpression(
                                                    new IdentifierExpression(
                                                        "source",
                                                        _IdentifierExpressions
                                                    ),
                                                    AphidTokenType.WhereOperator,
                                                    new IdentifierExpression(
                                                        "selector",
                                                        _IdentifierExpressions
                                                    )
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator234,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "target",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "arg",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new CallExpression(
                                                    new IdentifierExpression(
                                                        "target",
                                                        _IdentifierExpressions
                                                    ),
                                                    new List<AphidExpression>
                                                    {
                                                        new IdentifierExpression(
                                                            "arg",
                                                            _IdentifierExpressions
                                                        ),
                                                    }
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new FunctionExpression(
                                    new List<AphidExpression>
                                    {
                                        new IdentifierExpression(
                                            "___p_op_1",
                                            _IdentifierExpressions
                                        ),
                                    },
                                    new List<AphidExpression>
                                    {
                                        new UnaryOperatorExpression(
                                            AphidTokenType.retKeyword,
                                            new BinaryOperatorExpression(
                                                new IdentifierExpression(
                                                    "___p_op_1",
                                                    _IdentifierExpressions
                                                ),
                                                AphidTokenType.LessThanOperator,
                                                new FunctionExpression(
                                                    new List<AphidExpression>
                                                    {
                                                        new IdentifierExpression(
                                                            "f1",
                                                            _IdentifierExpressions
                                                        ),
                                                        new IdentifierExpression(
                                                            "f2",
                                                            _IdentifierExpressions
                                                        ),
                                                    },
                                                    new List<AphidExpression>
                                                    {
                                                        new UnaryOperatorExpression(
                                                            AphidTokenType.retKeyword,
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "f2",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.CompositionOperator,
                                                                new IdentifierExpression(
                                                                    "f1",
                                                                    _IdentifierExpressions
                                                                )
                                                            ),
                                                            false
                                                        ),
                                                    }
                                                )
                                            ),
                                            false
                                        ),
                                    }
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator113,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "file",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new CallExpression(
                                                    new BinaryOperatorExpression(
                                                        new IdentifierExpression(
                                                            "File",
                                                            _IdentifierExpressions
                                                        ),
                                                        AphidTokenType.MemberOperator,
                                                        new IdentifierExpression(
                                                            "ReadAllBytes",
                                                            _IdentifierExpressions
                                                        )
                                                    ),
                                                    new List<AphidExpression>
                                                    {
                                                        new CallExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "file",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.MemberOperator,
                                                                new IdentifierExpression(
                                                                    "ToString",
                                                                    _IdentifierExpressions
                                                                )
                                                            ),
                                                            _AphidExpressions
                                                        ),
                                                    }
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator279,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "file",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new CallExpression(
                                                    new BinaryOperatorExpression(
                                                        new IdentifierExpression(
                                                            "File",
                                                            _IdentifierExpressions
                                                        ),
                                                        AphidTokenType.MemberOperator,
                                                        new IdentifierExpression(
                                                            "ReadAllText",
                                                            _IdentifierExpressions
                                                        )
                                                    ),
                                                    new List<AphidExpression>
                                                    {
                                                        new CallExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "file",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.MemberOperator,
                                                                new IdentifierExpression(
                                                                    "ToString",
                                                                    _IdentifierExpressions
                                                                )
                                                            ),
                                                            _AphidExpressions
                                                        ),
                                                    }
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator182,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "text",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "file",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new BinaryOperatorExpression(
                                                    new CallExpression(
                                                        new BinaryOperatorExpression(
                                                            new IdentifierExpression(
                                                                "text",
                                                                _IdentifierExpressions
                                                            ),
                                                            AphidTokenType.MemberOperator,
                                                            new IdentifierExpression(
                                                                "ToString",
                                                                _IdentifierExpressions
                                                            )
                                                        ),
                                                        _AphidExpressions
                                                    ),
                                                    AphidTokenType.PipelineOperator,
                                                    new PartialFunctionExpression(
                                                        new CallExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "File",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.MemberOperator,
                                                                new IdentifierExpression(
                                                                    "WriteAllText",
                                                                    _IdentifierExpressions
                                                                )
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new CallExpression(
                                                                    new BinaryOperatorExpression(
                                                                        new IdentifierExpression(
                                                                            "file",
                                                                            _IdentifierExpressions
                                                                        ),
                                                                        AphidTokenType.MemberOperator,
                                                                        new IdentifierExpression(
                                                                            "ToString",
                                                                            _IdentifierExpressions
                                                                        )
                                                                    ),
                                                                    _AphidExpressions
                                                                ),
                                                            }
                                                        )
                                                    )
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator172,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "buffer",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "file",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new BinaryOperatorExpression(
                                                    new IdentifierExpression(
                                                        "buffer",
                                                        _IdentifierExpressions
                                                    ),
                                                    AphidTokenType.PipelineOperator,
                                                    new PartialFunctionExpression(
                                                        new CallExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "File",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.MemberOperator,
                                                                new IdentifierExpression(
                                                                    "WriteAllBytes",
                                                                    _IdentifierExpressions
                                                                )
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new CallExpression(
                                                                    new BinaryOperatorExpression(
                                                                        new IdentifierExpression(
                                                                            "file",
                                                                            _IdentifierExpressions
                                                                        ),
                                                                        AphidTokenType.MemberOperator,
                                                                        new IdentifierExpression(
                                                                            "ToString",
                                                                            _IdentifierExpressions
                                                                        )
                                                                    ),
                                                                    _AphidExpressions
                                                                ),
                                                            }
                                                        )
                                                    )
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator185,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "lhs",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "rhs",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new BinaryOperatorExpression(
                                                new IdentifierExpression(
                                                    "s",
                                                    new List<IdentifierExpression>
                                                    {
                                                        new IdentifierExpression(
                                                            "var",
                                                            _IdentifierExpressions
                                                        ),
                                                    }
                                                ),
                                                AphidTokenType.AssignmentOperator,
                                                new BinaryOperatorExpression(
                                                    new CallExpression(
                                                        new IdentifierExpression(
                                                            "frame",
                                                            _IdentifierExpressions
                                                        ),
                                                        _AphidExpressions
                                                    ),
                                                    AphidTokenType.MemberOperator,
                                                    new IdentifierExpression(
                                                        "Scope",
                                                        _IdentifierExpressions
                                                    )
                                                )
                                            ),
                                            new BinaryOperatorExpression(
                                                new IdentifierExpression(
                                                    "args",
                                                    new List<IdentifierExpression>
                                                    {
                                                        new IdentifierExpression(
                                                            "var",
                                                            _IdentifierExpressions
                                                        ),
                                                    }
                                                ),
                                                AphidTokenType.AssignmentOperator,
                                                new BinaryOperatorExpression(
                                                    new IdentifierExpression(
                                                        "s",
                                                        _IdentifierExpressions
                                                    ),
                                                    AphidTokenType.MemberOperator,
                                                    new DynamicMemberExpression(
                                                        new StringExpression(
                                                            "'$args'"
                                                        )
                                                    )
                                                )
                                            ),
                                            new BinaryOperatorExpression(
                                                new IdentifierExpression(
                                                    "i",
                                                    new List<IdentifierExpression>
                                                    {
                                                        new IdentifierExpression(
                                                            "var",
                                                            _IdentifierExpressions
                                                        ),
                                                    }
                                                ),
                                                AphidTokenType.AssignmentOperator,
                                                new TernaryOperatorExpression(
                                                    AphidTokenType.ConditionalOperator,
                                                    new UnaryOperatorExpression(
                                                        AphidTokenType.definedKeyword,
                                                        new BinaryOperatorExpression(
                                                            new IdentifierExpression(
                                                                "s",
                                                                _IdentifierExpressions
                                                            ),
                                                            AphidTokenType.MemberOperator,
                                                            new IdentifierExpression(
                                                                "argIndex",
                                                                _IdentifierExpressions
                                                            )
                                                        ),
                                                        true
                                                    ),
                                                    new UnaryOperatorExpression(
                                                        AphidTokenType.IncrementOperator,
                                                        new BinaryOperatorExpression(
                                                            new IdentifierExpression(
                                                                "s",
                                                                _IdentifierExpressions
                                                            ),
                                                            AphidTokenType.MemberOperator,
                                                            new IdentifierExpression(
                                                                "argIndex",
                                                                _IdentifierExpressions
                                                            )
                                                        ),
                                                        true
                                                    ),
                                                    new BinaryOperatorExpression(
                                                        new BinaryOperatorExpression(
                                                            new IdentifierExpression(
                                                                "s",
                                                                _IdentifierExpressions
                                                            ),
                                                            AphidTokenType.MemberOperator,
                                                            new IdentifierExpression(
                                                                "argIndex",
                                                                _IdentifierExpressions
                                                            )
                                                        ),
                                                        AphidTokenType.AssignmentOperator,
                                                        new NumberExpression(
                                                            1
                                                        )
                                                    )
                                                )
                                            ),
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new TernaryOperatorExpression(
                                                    AphidTokenType.ConditionalOperator,
                                                    new BinaryOperatorExpression(
                                                        new BinaryOperatorExpression(
                                                            new ImplicitArgumentsExpression(
                                                                AphidTokenType.ImplicitArgumentsOperator
                                                            ),
                                                            AphidTokenType.MemberOperator,
                                                            new IdentifierExpression(
                                                                "Count",
                                                                _IdentifierExpressions
                                                            )
                                                        ),
                                                        AphidTokenType.LessThanOperator,
                                                        new IdentifierExpression(
                                                            "i",
                                                            _IdentifierExpressions
                                                        )
                                                    ),
                                                    new IdentifierExpression(
                                                        "lhs",
                                                        _IdentifierExpressions
                                                    ),
                                                    new BinaryOperatorExpression(
                                                        new IdentifierExpression(
                                                            "lhs",
                                                            _IdentifierExpressions
                                                        ),
                                                        AphidTokenType.AndOperator,
                                                        new IdentifierExpression(
                                                            "rhs",
                                                            _IdentifierExpressions
                                                        )
                                                    )
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator316,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "lhs",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "rhs",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new TernaryOperatorExpression(
                                                    AphidTokenType.ConditionalOperator,
                                                    new BinaryOperatorExpression(
                                                        new IdentifierExpression(
                                                            "lhs",
                                                            _IdentifierExpressions
                                                        ),
                                                        AphidTokenType.NotEqualOperator,
                                                        _NullExpression
                                                    ),
                                                    new BinaryOperatorExpression(
                                                        new IdentifierExpression(
                                                            "lhs",
                                                            _IdentifierExpressions
                                                        ),
                                                        AphidTokenType.MemberOperator,
                                                        new DynamicMemberExpression(
                                                            new BinaryOperatorExpression(
                                                                new BinaryOperatorExpression(
                                                                    new BinaryOperatorExpression(
                                                                        new CallExpression(
                                                                            new IdentifierExpression(
                                                                                "frame",
                                                                                _IdentifierExpressions
                                                                            ),
                                                                            new List<AphidExpression>
                                                                            {
                                                                                new NumberExpression(
                                                                                    0
                                                                                ),
                                                                            }
                                                                        ),
                                                                        AphidTokenType.MemberOperator,
                                                                        new IdentifierExpression(
                                                                            "Expression",
                                                                            _IdentifierExpressions
                                                                        )
                                                                    ),
                                                                    AphidTokenType.MemberOperator,
                                                                    new IdentifierExpression(
                                                                        "RightOperand",
                                                                        _IdentifierExpressions
                                                                    )
                                                                ),
                                                                AphidTokenType.MemberOperator,
                                                                new IdentifierExpression(
                                                                    "Identifier",
                                                                    _IdentifierExpressions
                                                                )
                                                            )
                                                        )
                                                    ),
                                                    _NullExpression
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator148,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "lhs",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "rhs",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new BinaryOperatorExpression(
                                                new IdentifierExpression(
                                                    "f",
                                                    new List<IdentifierExpression>
                                                    {
                                                        new IdentifierExpression(
                                                            "var",
                                                            _IdentifierExpressions
                                                        ),
                                                    }
                                                ),
                                                AphidTokenType.AssignmentOperator,
                                                new BinaryOperatorExpression(
                                                    new UnaryOperatorExpression(
                                                        AphidTokenType.newKeyword,
                                                        new CallExpression(
                                                            new IdentifierExpression(
                                                                "PartialOperatorExpression",
                                                                _IdentifierExpressions
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new CallExpression(
                                                                    new IdentifierExpression(
                                                                        "getToken",
                                                                        _IdentifierExpressions
                                                                    ),
                                                                    new List<AphidExpression>
                                                                    {
                                                                        new StringExpression(
                                                                            "'.'"
                                                                        ),
                                                                    }
                                                                ),
                                                                new BinaryOperatorExpression(
                                                                    new BinaryOperatorExpression(
                                                                        new CallExpression(
                                                                            new IdentifierExpression(
                                                                                "frame",
                                                                                _IdentifierExpressions
                                                                            ),
                                                                            new List<AphidExpression>
                                                                            {
                                                                                new NumberExpression(
                                                                                    0
                                                                                ),
                                                                            }
                                                                        ),
                                                                        AphidTokenType.MemberOperator,
                                                                        new IdentifierExpression(
                                                                            "Expression",
                                                                            _IdentifierExpressions
                                                                        )
                                                                    ),
                                                                    AphidTokenType.MemberOperator,
                                                                    new IdentifierExpression(
                                                                        "RightOperand",
                                                                        _IdentifierExpressions
                                                                    )
                                                                ),
                                                            }
                                                        ),
                                                        false
                                                    ),
                                                    AphidTokenType.PipelineOperator,
                                                    new BinaryOperatorExpression(
                                                        new BinaryOperatorExpression(
                                                            _ThisExpression,
                                                            AphidTokenType.MemberOperator,
                                                            new DynamicMemberExpression(
                                                                new StringExpression(
                                                                    "'$aphid'"
                                                                )
                                                            )
                                                        ),
                                                        AphidTokenType.MemberOperator,
                                                        new IdentifierExpression(
                                                            "Interpret",
                                                            _IdentifierExpressions
                                                        )
                                                    )
                                                )
                                            ),
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new BinaryOperatorExpression(
                                                    new IdentifierExpression(
                                                        "lhs",
                                                        _IdentifierExpressions
                                                    ),
                                                    AphidTokenType.SelectOperator,
                                                    new IdentifierExpression(
                                                        "f",
                                                        _IdentifierExpressions
                                                    )
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator084,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "lhs",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "rhs",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new BinaryOperatorExpression(
                                                new IdentifierExpression(
                                                    "f",
                                                    new List<IdentifierExpression>
                                                    {
                                                        new IdentifierExpression(
                                                            "var",
                                                            _IdentifierExpressions
                                                        ),
                                                    }
                                                ),
                                                AphidTokenType.AssignmentOperator,
                                                new BinaryOperatorExpression(
                                                    new UnaryOperatorExpression(
                                                        AphidTokenType.newKeyword,
                                                        new CallExpression(
                                                            new IdentifierExpression(
                                                                "PartialOperatorExpression",
                                                                _IdentifierExpressions
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new CallExpression(
                                                                    new IdentifierExpression(
                                                                        "getToken",
                                                                        _IdentifierExpressions
                                                                    ),
                                                                    new List<AphidExpression>
                                                                    {
                                                                        new StringExpression(
                                                                            "'.'"
                                                                        ),
                                                                    }
                                                                ),
                                                                new BinaryOperatorExpression(
                                                                    new BinaryOperatorExpression(
                                                                        new CallExpression(
                                                                            new IdentifierExpression(
                                                                                "frame",
                                                                                _IdentifierExpressions
                                                                            ),
                                                                            new List<AphidExpression>
                                                                            {
                                                                                new NumberExpression(
                                                                                    0
                                                                                ),
                                                                            }
                                                                        ),
                                                                        AphidTokenType.MemberOperator,
                                                                        new IdentifierExpression(
                                                                            "Expression",
                                                                            _IdentifierExpressions
                                                                        )
                                                                    ),
                                                                    AphidTokenType.MemberOperator,
                                                                    new IdentifierExpression(
                                                                        "RightOperand",
                                                                        _IdentifierExpressions
                                                                    )
                                                                ),
                                                            }
                                                        ),
                                                        false
                                                    ),
                                                    AphidTokenType.PipelineOperator,
                                                    new BinaryOperatorExpression(
                                                        new BinaryOperatorExpression(
                                                            _ThisExpression,
                                                            AphidTokenType.MemberOperator,
                                                            new DynamicMemberExpression(
                                                                new StringExpression(
                                                                    "'$aphid'"
                                                                )
                                                            )
                                                        ),
                                                        AphidTokenType.MemberOperator,
                                                        new IdentifierExpression(
                                                            "Interpret",
                                                            _IdentifierExpressions
                                                        )
                                                    )
                                                )
                                            ),
                                            new BinaryOperatorExpression(
                                                new IdentifierExpression(
                                                    "lhs",
                                                    _IdentifierExpressions
                                                ),
                                                AphidTokenType.SelectOperator,
                                                new FunctionExpression(
                                                    _AphidExpressions,
                                                    new List<AphidExpression>
                                                    {
                                                        new CallExpression(
                                                            new CallExpression(
                                                                new IdentifierExpression(
                                                                    "f",
                                                                    _IdentifierExpressions
                                                                ),
                                                                new List<AphidExpression>
                                                                {
                                                                    new ImplicitArgumentExpression(
                                                                        AphidTokenType.ImplicitArgumentOperator
                                                                    ),
                                                                }
                                                            ),
                                                            _AphidExpressions
                                                        ),
                                                    }
                                                )
                                            ),
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new IdentifierExpression(
                                                    "lhs",
                                                    _IdentifierExpressions
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator040,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "condition",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "fatalMessage",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new IfExpression(
                                                new IdentifierExpression(
                                                    "condition",
                                                    _IdentifierExpressions
                                                ),
                                                new List<AphidExpression>
                                                {
                                                    new CallExpression(
                                                        new IdentifierExpression(
                                                            "printCriticalError",
                                                            _IdentifierExpressions
                                                        ),
                                                        new List<AphidExpression>
                                                        {
                                                            new IdentifierExpression(
                                                                "fatalMessage",
                                                                _IdentifierExpressions
                                                            ),
                                                        }
                                                    ),
                                                    new CallExpression(
                                                        new BinaryOperatorExpression(
                                                            new IdentifierExpression(
                                                                "Environment",
                                                                _IdentifierExpressions
                                                            ),
                                                            AphidTokenType.MemberOperator,
                                                            new IdentifierExpression(
                                                                "Exit",
                                                                _IdentifierExpressions
                                                            )
                                                        ),
                                                        new List<AphidExpression>
                                                        {
                                                            new NumberExpression(
                                                                765186
                                                            ),
                                                        }
                                                    ),
                                                },
                                                null
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorBodyExpression(
                                    AphidTokenType.CustomOperator019,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                            new IdentifierExpression(
                                                "depth",
                                                _IdentifierExpressions
                                            ),
                                            new IdentifierExpression(
                                                "num",
                                                _IdentifierExpressions
                                            ),
                                        },
                                        new List<AphidExpression>
                                        {
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new TernaryOperatorExpression(
                                                    AphidTokenType.ConditionalOperator,
                                                    new BinaryOperatorExpression(
                                                        new BinaryOperatorExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "exp",
                                                                    new List<IdentifierExpression>
                                                                    {
                                                                        new IdentifierExpression(
                                                                            "var",
                                                                            _IdentifierExpressions
                                                                        ),
                                                                    }
                                                                ),
                                                                AphidTokenType.AssignmentOperator,
                                                                new BinaryOperatorExpression(
                                                                    new CallExpression(
                                                                        new IdentifierExpression(
                                                                            "frame",
                                                                            _IdentifierExpressions
                                                                        ),
                                                                        new List<AphidExpression>
                                                                        {
                                                                            new IdentifierExpression(
                                                                                "depth",
                                                                                _IdentifierExpressions
                                                                            ),
                                                                        }
                                                                    ),
                                                                    AphidTokenType.MemberOperator,
                                                                    new IdentifierExpression(
                                                                        "Expression",
                                                                        _IdentifierExpressions
                                                                    )
                                                                )
                                                            ),
                                                            AphidTokenType.MemberOperator,
                                                            new IdentifierExpression(
                                                                "Type",
                                                                _IdentifierExpressions
                                                            )
                                                        ),
                                                        AphidTokenType.EqualityOperator,
                                                        new BinaryOperatorExpression(
                                                            new IdentifierExpression(
                                                                "AphidExpressionType",
                                                                _IdentifierExpressions
                                                            ),
                                                            AphidTokenType.MemberOperator,
                                                            new IdentifierExpression(
                                                                "CallExpression",
                                                                _IdentifierExpressions
                                                            )
                                                        )
                                                    ),
                                                    new BinaryOperatorExpression(
                                                        new ArrayAccessExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "exp",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.MemberOperator,
                                                                new IdentifierExpression(
                                                                    "Args",
                                                                    _IdentifierExpressions
                                                                )
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new IdentifierExpression(
                                                                    "num",
                                                                    _IdentifierExpressions
                                                                ),
                                                            }
                                                        ),
                                                        AphidTokenType.MemberOperator,
                                                        new IdentifierExpression(
                                                            "Identifier",
                                                            _IdentifierExpressions
                                                        )
                                                    ),
                                                    new TernaryOperatorExpression(
                                                        AphidTokenType.ConditionalOperator,
                                                        new BinaryOperatorExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "exp",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.MemberOperator,
                                                                new IdentifierExpression(
                                                                    "Type",
                                                                    _IdentifierExpressions
                                                                )
                                                            ),
                                                            AphidTokenType.EqualityOperator,
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "AphidExpressionType",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.MemberOperator,
                                                                new IdentifierExpression(
                                                                    "BinaryOperatorExpression",
                                                                    _IdentifierExpressions
                                                                )
                                                            )
                                                        ),
                                                        new PatternMatchingExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "exp",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.MemberOperator,
                                                                new IdentifierExpression(
                                                                    "Operator",
                                                                    _IdentifierExpressions
                                                                )
                                                            ),
                                                            new List<PatternExpression>
                                                            {
                                                                new PatternExpression(
                                                                    new TernaryOperatorExpression(
                                                                        AphidTokenType.ConditionalOperator,
                                                                        new BinaryOperatorExpression(
                                                                            new IdentifierExpression(
                                                                                "num",
                                                                                _IdentifierExpressions
                                                                            ),
                                                                            AphidTokenType.EqualityOperator,
                                                                            new NumberExpression(
                                                                                0
                                                                            )
                                                                        ),
                                                                        new BinaryOperatorExpression(
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "exp",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.MemberOperator,
                                                                                new IdentifierExpression(
                                                                                    "LeftOperand",
                                                                                    _IdentifierExpressions
                                                                                )
                                                                            ),
                                                                            AphidTokenType.MemberOperator,
                                                                            new IdentifierExpression(
                                                                                "Identifier",
                                                                                _IdentifierExpressions
                                                                            )
                                                                        ),
                                                                        new CallExpression(
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "ex",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.MemberOperator,
                                                                                new IdentifierExpression(
                                                                                    "arg",
                                                                                    _IdentifierExpressions
                                                                                )
                                                                            ),
                                                                            new List<AphidExpression>
                                                                            {
                                                                                new IdentifierExpression(
                                                                                    "num",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                            }
                                                                        )
                                                                    ),
                                                                    new List<AphidExpression>
                                                                    {
                                                                        new BinaryOperatorExpression(
                                                                            new IdentifierExpression(
                                                                                "AphidTokenType",
                                                                                _IdentifierExpressions
                                                                            ),
                                                                            AphidTokenType.MemberOperator,
                                                                            new IdentifierExpression(
                                                                                "BinaryOrOperator",
                                                                                _IdentifierExpressions
                                                                            )
                                                                        ),
                                                                        new BinaryOperatorExpression(
                                                                            new IdentifierExpression(
                                                                                "AphidTokenType",
                                                                                _IdentifierExpressions
                                                                            ),
                                                                            AphidTokenType.MemberOperator,
                                                                            new IdentifierExpression(
                                                                                "PipelineOperator",
                                                                                _IdentifierExpressions
                                                                            )
                                                                        ),
                                                                    }
                                                                ),
                                                                new PatternExpression(
                                                                    new TernaryOperatorExpression(
                                                                        AphidTokenType.ConditionalOperator,
                                                                        new BinaryOperatorExpression(
                                                                            new IdentifierExpression(
                                                                                "num",
                                                                                _IdentifierExpressions
                                                                            ),
                                                                            AphidTokenType.EqualityOperator,
                                                                            new NumberExpression(
                                                                                0
                                                                            )
                                                                        ),
                                                                        new BinaryOperatorExpression(
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "exp",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.MemberOperator,
                                                                                new IdentifierExpression(
                                                                                    "RightOperand",
                                                                                    _IdentifierExpressions
                                                                                )
                                                                            ),
                                                                            AphidTokenType.MemberOperator,
                                                                            new IdentifierExpression(
                                                                                "Identifier",
                                                                                _IdentifierExpressions
                                                                            )
                                                                        ),
                                                                        new CallExpression(
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "ex",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.MemberOperator,
                                                                                new IdentifierExpression(
                                                                                    "arg",
                                                                                    _IdentifierExpressions
                                                                                )
                                                                            ),
                                                                            new List<AphidExpression>
                                                                            {
                                                                                new IdentifierExpression(
                                                                                    "num",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                            }
                                                                        )
                                                                    ),
                                                                    new List<AphidExpression>
                                                                    {
                                                                        new BinaryOperatorExpression(
                                                                            new IdentifierExpression(
                                                                                "AphidTokenType",
                                                                                _IdentifierExpressions
                                                                            ),
                                                                            AphidTokenType.MemberOperator,
                                                                            new IdentifierExpression(
                                                                                "CustomOperator234",
                                                                                _IdentifierExpressions
                                                                            )
                                                                        ),
                                                                    }
                                                                ),
                                                            }
                                                        ),
                                                        new CallExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "ex",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.MemberOperator,
                                                                new IdentifierExpression(
                                                                    "arg",
                                                                    _IdentifierExpressions
                                                                )
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new IdentifierExpression(
                                                                    "num",
                                                                    _IdentifierExpressions
                                                                ),
                                                            }
                                                        )
                                                    )
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                new BinaryOperatorExpression(
                                    new IdentifierExpression(
                                        "defaultRegexOptions",
                                        new List<IdentifierExpression>
                                        {
                                            new IdentifierExpression(
                                                "var",
                                                _IdentifierExpressions
                                            ),
                                        }
                                    ),
                                    AphidTokenType.AssignmentOperator,
                                    new BinaryOperatorExpression(
                                        new BinaryOperatorExpression(
                                            new IdentifierExpression(
                                                "RegexOptions",
                                                _IdentifierExpressions
                                            ),
                                            AphidTokenType.MemberOperator,
                                            new IdentifierExpression(
                                                "IgnoreCase",
                                                _IdentifierExpressions
                                            )
                                        ),
                                        AphidTokenType.BinaryOrOperator,
                                        new BinaryOperatorExpression(
                                            new IdentifierExpression(
                                                "RegexOptions",
                                                _IdentifierExpressions
                                            ),
                                            AphidTokenType.MemberOperator,
                                            new IdentifierExpression(
                                                "Compiled",
                                                _IdentifierExpressions
                                            )
                                        )
                                    )
                                ),
                                new IdentifierExpression(
                                    "keyboard",
                                    new List<IdentifierExpression>
                                    {
                                        new IdentifierExpression(
                                            "var",
                                            _IdentifierExpressions
                                        ),
                                    }
                                ),
                                new UnaryOperatorExpression(
                                    AphidTokenType.usingKeyword,
                                    new BinaryOperatorExpression(
                                        new BinaryOperatorExpression(
                                            new IdentifierExpression(
                                                "System",
                                                _IdentifierExpressions
                                            ),
                                            AphidTokenType.MemberOperator,
                                            new IdentifierExpression(
                                                "Windows",
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
                                new CallExpression(
                                    new FunctionExpression(
                                        _AphidExpressions,
                                        new List<AphidExpression>
                                        {
                                            new UnaryOperatorExpression(
                                                AphidTokenType.loadKeyword,
                                                new IdentifierExpression(
                                                    "WindowsBase",
                                                    _IdentifierExpressions
                                                ),
                                                false
                                            ),
                                            new UnaryOperatorExpression(
                                                AphidTokenType.usingKeyword,
                                                new BinaryOperatorExpression(
                                                    new IdentifierExpression(
                                                        "Components",
                                                        _IdentifierExpressions
                                                    ),
                                                    AphidTokenType.MemberOperator,
                                                    new IdentifierExpression(
                                                        "PInvoke",
                                                        _IdentifierExpressions
                                                    )
                                                ),
                                                false
                                            ),
                                            new UnaryOperatorExpression(
                                                AphidTokenType.usingKeyword,
                                                new IdentifierExpression(
                                                    "System",
                                                    _IdentifierExpressions
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
                                                        "Threading",
                                                        _IdentifierExpressions
                                                    )
                                                ),
                                                false
                                            ),
                                            new BinaryOperatorExpression(
                                                new IdentifierExpression(
                                                    "keyboard",
                                                    _IdentifierExpressions
                                                ),
                                                AphidTokenType.AssignmentOperator,
                                                new ObjectExpression(
                                                    new List<BinaryOperatorExpression>
                                                    {
                                                        new BinaryOperatorExpression(
                                                            new IdentifierExpression(
                                                                "type",
                                                                _IdentifierExpressions
                                                            ),
                                                            AphidTokenType.ColonOperator,
                                                            new FunctionExpression(
                                                                new List<AphidExpression>
                                                                {
                                                                    new IdentifierExpression(
                                                                        "buffer",
                                                                        _IdentifierExpressions
                                                                    ),
                                                                },
                                                                new List<AphidExpression>
                                                                {
                                                                    new UnaryOperatorExpression(
                                                                        AphidTokenType.retKeyword,
                                                                        new BinaryOperatorExpression(
                                                                            new BinaryOperatorExpression(
                                                                                new CallExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "buffer",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "ToCharArray",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    _AphidExpressions
                                                                                ),
                                                                                AphidTokenType.PipelineOperator,
                                                                                new IdentifierExpression(
                                                                                    "parseKeyBuffer",
                                                                                    _IdentifierExpressions
                                                                                )
                                                                            ),
                                                                            AphidTokenType.SelectOperator,
                                                                            new IdentifierExpression(
                                                                                "pressChar",
                                                                                _IdentifierExpressions
                                                                            )
                                                                        ),
                                                                        false
                                                                    ),
                                                                }
                                                            )
                                                        ),
                                                        new BinaryOperatorExpression(
                                                            new IdentifierExpression(
                                                                "pressChar",
                                                                _IdentifierExpressions
                                                            ),
                                                            AphidTokenType.ColonOperator,
                                                            new FunctionExpression(
                                                                new List<AphidExpression>
                                                                {
                                                                    new IdentifierExpression(
                                                                        "ci",
                                                                        _IdentifierExpressions
                                                                    ),
                                                                },
                                                                new List<AphidExpression>
                                                                {
                                                                    new IfExpression(
                                                                        new BinaryOperatorExpression(
                                                                            new IdentifierExpression(
                                                                                "ci",
                                                                                _IdentifierExpressions
                                                                            ),
                                                                            AphidTokenType.MemberOperator,
                                                                            new IdentifierExpression(
                                                                                "shift",
                                                                                _IdentifierExpressions
                                                                            )
                                                                        ),
                                                                        new List<AphidExpression>
                                                                        {
                                                                            new CallExpression(
                                                                                new IdentifierExpression(
                                                                                    "shiftDown",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                _AphidExpressions
                                                                            ),
                                                                            new CallExpression(
                                                                                new IdentifierExpression(
                                                                                    "pressKey",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                new List<AphidExpression>
                                                                                {
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "ci",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "key",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                }
                                                                            ),
                                                                            new CallExpression(
                                                                                new IdentifierExpression(
                                                                                    "shiftUp",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                _AphidExpressions
                                                                            ),
                                                                        },
                                                                        new List<AphidExpression>
                                                                        {
                                                                            new CallExpression(
                                                                                new IdentifierExpression(
                                                                                    "pressKey",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                new List<AphidExpression>
                                                                                {
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "ci",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "key",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                }
                                                                            ),
                                                                        }
                                                                    ),
                                                                }
                                                            )
                                                        ),
                                                        new BinaryOperatorExpression(
                                                            new IdentifierExpression(
                                                                "shiftDown",
                                                                _IdentifierExpressions
                                                            ),
                                                            AphidTokenType.ColonOperator,
                                                            new FunctionExpression(
                                                                _AphidExpressions,
                                                                new List<AphidExpression>
                                                                {
                                                                    new UnaryOperatorExpression(
                                                                        AphidTokenType.retKeyword,
                                                                        new CallExpression(
                                                                            new IdentifierExpression(
                                                                                "keyDown",
                                                                                _IdentifierExpressions
                                                                            ),
                                                                            new List<AphidExpression>
                                                                            {
                                                                                new BinaryOperatorExpression(
                                                                                    new IdentifierExpression(
                                                                                        "Key",
                                                                                        _IdentifierExpressions
                                                                                    ),
                                                                                    AphidTokenType.MemberOperator,
                                                                                    new IdentifierExpression(
                                                                                        "LeftShift",
                                                                                        _IdentifierExpressions
                                                                                    )
                                                                                ),
                                                                            }
                                                                        ),
                                                                        false
                                                                    ),
                                                                }
                                                            )
                                                        ),
                                                        new BinaryOperatorExpression(
                                                            new IdentifierExpression(
                                                                "shiftUp",
                                                                _IdentifierExpressions
                                                            ),
                                                            AphidTokenType.ColonOperator,
                                                            new FunctionExpression(
                                                                _AphidExpressions,
                                                                new List<AphidExpression>
                                                                {
                                                                    new UnaryOperatorExpression(
                                                                        AphidTokenType.retKeyword,
                                                                        new CallExpression(
                                                                            new IdentifierExpression(
                                                                                "keyUp",
                                                                                _IdentifierExpressions
                                                                            ),
                                                                            new List<AphidExpression>
                                                                            {
                                                                                new BinaryOperatorExpression(
                                                                                    new IdentifierExpression(
                                                                                        "Key",
                                                                                        _IdentifierExpressions
                                                                                    ),
                                                                                    AphidTokenType.MemberOperator,
                                                                                    new IdentifierExpression(
                                                                                        "LeftShift",
                                                                                        _IdentifierExpressions
                                                                                    )
                                                                                ),
                                                                            }
                                                                        ),
                                                                        false
                                                                    ),
                                                                }
                                                            )
                                                        ),
                                                        new BinaryOperatorExpression(
                                                            new IdentifierExpression(
                                                                "keyDown",
                                                                _IdentifierExpressions
                                                            ),
                                                            AphidTokenType.ColonOperator,
                                                            new FunctionExpression(
                                                                new List<AphidExpression>
                                                                {
                                                                    new IdentifierExpression(
                                                                        "key",
                                                                        _IdentifierExpressions
                                                                    ),
                                                                },
                                                                new List<AphidExpression>
                                                                {
                                                                    new CallExpression(
                                                                        new BinaryOperatorExpression(
                                                                            new IdentifierExpression(
                                                                                "User32",
                                                                                _IdentifierExpressions
                                                                            ),
                                                                            AphidTokenType.MemberOperator,
                                                                            new IdentifierExpression(
                                                                                "keybd_event",
                                                                                _IdentifierExpressions
                                                                            )
                                                                        ),
                                                                        new List<AphidExpression>
                                                                        {
                                                                            new BinaryOperatorExpression(
                                                                                new BinaryOperatorExpression(
                                                                                    new IdentifierExpression(
                                                                                        "key",
                                                                                        _IdentifierExpressions
                                                                                    ),
                                                                                    AphidTokenType.PipelineOperator,
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "KeyInterop",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "VirtualKeyFromKey",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    )
                                                                                ),
                                                                                AphidTokenType.PipelineOperator,
                                                                                new BinaryOperatorExpression(
                                                                                    new IdentifierExpression(
                                                                                        "Convert",
                                                                                        _IdentifierExpressions
                                                                                    ),
                                                                                    AphidTokenType.MemberOperator,
                                                                                    new IdentifierExpression(
                                                                                        "ToByte",
                                                                                        _IdentifierExpressions
                                                                                    )
                                                                                )
                                                                            ),
                                                                            new BinaryOperatorExpression(
                                                                                new NumberExpression(
                                                                                    0
                                                                                ),
                                                                                AphidTokenType.PipelineOperator,
                                                                                new BinaryOperatorExpression(
                                                                                    new IdentifierExpression(
                                                                                        "Convert",
                                                                                        _IdentifierExpressions
                                                                                    ),
                                                                                    AphidTokenType.MemberOperator,
                                                                                    new IdentifierExpression(
                                                                                        "ToByte",
                                                                                        _IdentifierExpressions
                                                                                    )
                                                                                )
                                                                            ),
                                                                            new BinaryOperatorExpression(
                                                                                new NumberExpression(
                                                                                    0
                                                                                ),
                                                                                AphidTokenType.PipelineOperator,
                                                                                new BinaryOperatorExpression(
                                                                                    new IdentifierExpression(
                                                                                        "Convert",
                                                                                        _IdentifierExpressions
                                                                                    ),
                                                                                    AphidTokenType.MemberOperator,
                                                                                    new IdentifierExpression(
                                                                                        "ToInt32",
                                                                                        _IdentifierExpressions
                                                                                    )
                                                                                )
                                                                            ),
                                                                            new BinaryOperatorExpression(
                                                                                new NumberExpression(
                                                                                    0
                                                                                ),
                                                                                AphidTokenType.PipelineOperator,
                                                                                new BinaryOperatorExpression(
                                                                                    new IdentifierExpression(
                                                                                        "Convert",
                                                                                        _IdentifierExpressions
                                                                                    ),
                                                                                    AphidTokenType.MemberOperator,
                                                                                    new IdentifierExpression(
                                                                                        "ToInt32",
                                                                                        _IdentifierExpressions
                                                                                    )
                                                                                )
                                                                            ),
                                                                        }
                                                                    ),
                                                                    new CallExpression(
                                                                        new BinaryOperatorExpression(
                                                                            new IdentifierExpression(
                                                                                "__impl",
                                                                                _IdentifierExpressions
                                                                            ),
                                                                            AphidTokenType.MemberOperator,
                                                                            new IdentifierExpression(
                                                                                "sleep",
                                                                                _IdentifierExpressions
                                                                            )
                                                                        ),
                                                                        _AphidExpressions
                                                                    ),
                                                                }
                                                            )
                                                        ),
                                                        new BinaryOperatorExpression(
                                                            new IdentifierExpression(
                                                                "keyUp",
                                                                _IdentifierExpressions
                                                            ),
                                                            AphidTokenType.ColonOperator,
                                                            new FunctionExpression(
                                                                new List<AphidExpression>
                                                                {
                                                                    new IdentifierExpression(
                                                                        "key",
                                                                        _IdentifierExpressions
                                                                    ),
                                                                },
                                                                new List<AphidExpression>
                                                                {
                                                                    new CallExpression(
                                                                        new BinaryOperatorExpression(
                                                                            new IdentifierExpression(
                                                                                "User32",
                                                                                _IdentifierExpressions
                                                                            ),
                                                                            AphidTokenType.MemberOperator,
                                                                            new IdentifierExpression(
                                                                                "keybd_event",
                                                                                _IdentifierExpressions
                                                                            )
                                                                        ),
                                                                        new List<AphidExpression>
                                                                        {
                                                                            new BinaryOperatorExpression(
                                                                                new BinaryOperatorExpression(
                                                                                    new IdentifierExpression(
                                                                                        "key",
                                                                                        _IdentifierExpressions
                                                                                    ),
                                                                                    AphidTokenType.PipelineOperator,
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "KeyInterop",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "VirtualKeyFromKey",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    )
                                                                                ),
                                                                                AphidTokenType.PipelineOperator,
                                                                                new BinaryOperatorExpression(
                                                                                    new IdentifierExpression(
                                                                                        "Convert",
                                                                                        _IdentifierExpressions
                                                                                    ),
                                                                                    AphidTokenType.MemberOperator,
                                                                                    new IdentifierExpression(
                                                                                        "ToByte",
                                                                                        _IdentifierExpressions
                                                                                    )
                                                                                )
                                                                            ),
                                                                            new BinaryOperatorExpression(
                                                                                new NumberExpression(
                                                                                    0
                                                                                ),
                                                                                AphidTokenType.PipelineOperator,
                                                                                new BinaryOperatorExpression(
                                                                                    new IdentifierExpression(
                                                                                        "Convert",
                                                                                        _IdentifierExpressions
                                                                                    ),
                                                                                    AphidTokenType.MemberOperator,
                                                                                    new IdentifierExpression(
                                                                                        "ToByte",
                                                                                        _IdentifierExpressions
                                                                                    )
                                                                                )
                                                                            ),
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "User32",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.MemberOperator,
                                                                                new IdentifierExpression(
                                                                                    "KEYEVENTF_KEYUP",
                                                                                    _IdentifierExpressions
                                                                                )
                                                                            ),
                                                                            new BinaryOperatorExpression(
                                                                                new NumberExpression(
                                                                                    0
                                                                                ),
                                                                                AphidTokenType.PipelineOperator,
                                                                                new BinaryOperatorExpression(
                                                                                    new IdentifierExpression(
                                                                                        "Convert",
                                                                                        _IdentifierExpressions
                                                                                    ),
                                                                                    AphidTokenType.MemberOperator,
                                                                                    new IdentifierExpression(
                                                                                        "ToInt32",
                                                                                        _IdentifierExpressions
                                                                                    )
                                                                                )
                                                                            ),
                                                                        }
                                                                    ),
                                                                    new CallExpression(
                                                                        new BinaryOperatorExpression(
                                                                            new IdentifierExpression(
                                                                                "__impl",
                                                                                _IdentifierExpressions
                                                                            ),
                                                                            AphidTokenType.MemberOperator,
                                                                            new IdentifierExpression(
                                                                                "sleep",
                                                                                _IdentifierExpressions
                                                                            )
                                                                        ),
                                                                        _AphidExpressions
                                                                    ),
                                                                }
                                                            )
                                                        ),
                                                        new BinaryOperatorExpression(
                                                            new IdentifierExpression(
                                                                "pressKey",
                                                                _IdentifierExpressions
                                                            ),
                                                            AphidTokenType.ColonOperator,
                                                            new FunctionExpression(
                                                                new List<AphidExpression>
                                                                {
                                                                    new IdentifierExpression(
                                                                        "key",
                                                                        _IdentifierExpressions
                                                                    ),
                                                                },
                                                                new List<AphidExpression>
                                                                {
                                                                    new UnaryOperatorExpression(
                                                                        AphidTokenType.retKeyword,
                                                                        new BinaryOperatorExpression(
                                                                            new ArrayExpression(
                                                                                new List<AphidExpression>
                                                                                {
                                                                                    new IdentifierExpression(
                                                                                        "keyDown",
                                                                                        _IdentifierExpressions
                                                                                    ),
                                                                                    new IdentifierExpression(
                                                                                        "keyUp",
                                                                                        _IdentifierExpressions
                                                                                    ),
                                                                                }
                                                                            ),
                                                                            AphidTokenType.SelectOperator,
                                                                            new FunctionExpression(
                                                                                _AphidExpressions,
                                                                                new List<AphidExpression>
                                                                                {
                                                                                    new UnaryOperatorExpression(
                                                                                        AphidTokenType.retKeyword,
                                                                                        new BinaryOperatorExpression(
                                                                                            new ImplicitArgumentExpression(
                                                                                                AphidTokenType.ImplicitArgumentOperator
                                                                                            ),
                                                                                            AphidTokenType.CustomOperator234,
                                                                                            new IdentifierExpression(
                                                                                                "key",
                                                                                                _IdentifierExpressions
                                                                                            )
                                                                                        ),
                                                                                        false
                                                                                    ),
                                                                                }
                                                                            )
                                                                        ),
                                                                        false
                                                                    ),
                                                                }
                                                            )
                                                        ),
                                                        new BinaryOperatorExpression(
                                                            new IdentifierExpression(
                                                                "keystrokeMinMs",
                                                                _IdentifierExpressions
                                                            ),
                                                            AphidTokenType.ColonOperator,
                                                            new NumberExpression(
                                                                10
                                                            )
                                                        ),
                                                        new BinaryOperatorExpression(
                                                            new IdentifierExpression(
                                                                "keystrokeMaxMs",
                                                                _IdentifierExpressions
                                                            ),
                                                            AphidTokenType.ColonOperator,
                                                            new NumberExpression(
                                                                35
                                                            )
                                                        ),
                                                        new BinaryOperatorExpression(
                                                            new IdentifierExpression(
                                                                "__impl",
                                                                _IdentifierExpressions
                                                            ),
                                                            AphidTokenType.ColonOperator,
                                                            new ObjectExpression(
                                                                new List<BinaryOperatorExpression>
                                                                {
                                                                    new BinaryOperatorExpression(
                                                                        new IdentifierExpression(
                                                                            "rnd",
                                                                            _IdentifierExpressions
                                                                        ),
                                                                        AphidTokenType.ColonOperator,
                                                                        new UnaryOperatorExpression(
                                                                            AphidTokenType.newKeyword,
                                                                            new CallExpression(
                                                                                new IdentifierExpression(
                                                                                    "Random",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                _AphidExpressions
                                                                            ),
                                                                            false
                                                                        )
                                                                    ),
                                                                    new BinaryOperatorExpression(
                                                                        new IdentifierExpression(
                                                                            "nextMs",
                                                                            _IdentifierExpressions
                                                                        ),
                                                                        AphidTokenType.ColonOperator,
                                                                        new FunctionExpression(
                                                                            _AphidExpressions,
                                                                            new List<AphidExpression>
                                                                            {
                                                                                new LockExpression(
                                                                                    new List<AphidExpression>
                                                                                    {
                                                                                        new IdentifierExpression(
                                                                                            "rnd",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                    },
                                                                                    new List<AphidExpression>
                                                                                    {
                                                                                        new UnaryOperatorExpression(
                                                                                            AphidTokenType.retKeyword,
                                                                                            new CallExpression(
                                                                                                new BinaryOperatorExpression(
                                                                                                    new IdentifierExpression(
                                                                                                        "rnd",
                                                                                                        _IdentifierExpressions
                                                                                                    ),
                                                                                                    AphidTokenType.MemberOperator,
                                                                                                    new IdentifierExpression(
                                                                                                        "Next",
                                                                                                        _IdentifierExpressions
                                                                                                    )
                                                                                                ),
                                                                                                new List<AphidExpression>
                                                                                                {
                                                                                                    new IdentifierExpression(
                                                                                                        "keystrokeMinMs",
                                                                                                        _IdentifierExpressions
                                                                                                    ),
                                                                                                    new BinaryOperatorExpression(
                                                                                                        new IdentifierExpression(
                                                                                                            "keystrokeMaxMs",
                                                                                                            _IdentifierExpressions
                                                                                                        ),
                                                                                                        AphidTokenType.AdditionOperator,
                                                                                                        new NumberExpression(
                                                                                                            1
                                                                                                        )
                                                                                                    ),
                                                                                                }
                                                                                            ),
                                                                                            false
                                                                                        ),
                                                                                    }
                                                                                ),
                                                                            }
                                                                        )
                                                                    ),
                                                                    new BinaryOperatorExpression(
                                                                        new IdentifierExpression(
                                                                            "sleep",
                                                                            _IdentifierExpressions
                                                                        ),
                                                                        AphidTokenType.ColonOperator,
                                                                        new BinaryOperatorExpression(
                                                                            new IdentifierExpression(
                                                                                "nextMs",
                                                                                _IdentifierExpressions
                                                                            ),
                                                                            AphidTokenType.CompositionOperator,
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "Thread",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.MemberOperator,
                                                                                new IdentifierExpression(
                                                                                    "Sleep",
                                                                                    _IdentifierExpressions
                                                                                )
                                                                            )
                                                                        )
                                                                    ),
                                                                },
                                                                null
                                                            )
                                                        ),
                                                    },
                                                    null
                                                )
                                            ),
                                            new BinaryOperatorExpression(
                                                new IdentifierExpression(
                                                    "conv",
                                                    new List<IdentifierExpression>
                                                    {
                                                        new IdentifierExpression(
                                                            "var",
                                                            _IdentifierExpressions
                                                        ),
                                                    }
                                                ),
                                                AphidTokenType.AssignmentOperator,
                                                new UnaryOperatorExpression(
                                                    AphidTokenType.newKeyword,
                                                    new CallExpression(
                                                        new IdentifierExpression(
                                                            "KeyConverter",
                                                            _IdentifierExpressions
                                                        ),
                                                        _AphidExpressions
                                                    ),
                                                    false
                                                )
                                            ),
                                            new BinaryOperatorExpression(
                                                new IdentifierExpression(
                                                    "parseKeyBuffer",
                                                    new List<IdentifierExpression>
                                                    {
                                                        new IdentifierExpression(
                                                            "var",
                                                            _IdentifierExpressions
                                                        ),
                                                    }
                                                ),
                                                AphidTokenType.AssignmentOperator,
                                                new FunctionExpression(
                                                    new List<AphidExpression>
                                                    {
                                                        new IdentifierExpression(
                                                            "buffer",
                                                            _IdentifierExpressions
                                                        ),
                                                    },
                                                    new List<AphidExpression>
                                                    {
                                                        new UnaryOperatorExpression(
                                                            AphidTokenType.retKeyword,
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "buffer",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.SelectOperator,
                                                                new IdentifierExpression(
                                                                    "parseKey",
                                                                    _IdentifierExpressions
                                                                )
                                                            ),
                                                            false
                                                        ),
                                                    }
                                                )
                                            ),
                                            new BinaryOperatorExpression(
                                                new IdentifierExpression(
                                                    "parseKey",
                                                    new List<IdentifierExpression>
                                                    {
                                                        new IdentifierExpression(
                                                            "var",
                                                            _IdentifierExpressions
                                                        ),
                                                    }
                                                ),
                                                AphidTokenType.AssignmentOperator,
                                                new FunctionExpression(
                                                    new List<AphidExpression>
                                                    {
                                                        new IdentifierExpression(
                                                            "c",
                                                            _IdentifierExpressions
                                                        ),
                                                    },
                                                    new List<AphidExpression>
                                                    {
                                                        new IfExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "c",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.EqualityOperator,
                                                                new StringExpression(
                                                                    "'!'"
                                                                )
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new UnaryOperatorExpression(
                                                                    AphidTokenType.retKeyword,
                                                                    new ObjectExpression(
                                                                        new List<BinaryOperatorExpression>
                                                                        {
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "shift",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BooleanExpression(
                                                                                    true
                                                                                )
                                                                            ),
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "key",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BinaryOperatorExpression(
                                                                                    new StringExpression(
                                                                                        "'1'"
                                                                                    ),
                                                                                    AphidTokenType.PipelineOperator,
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "conv",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "ConvertFromString",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    )
                                                                                )
                                                                            ),
                                                                        },
                                                                        null
                                                                    ),
                                                                    false
                                                                ),
                                                            },
                                                            null
                                                        ),
                                                        new IfExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "c",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.EqualityOperator,
                                                                new StringExpression(
                                                                    "'@'"
                                                                )
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new UnaryOperatorExpression(
                                                                    AphidTokenType.retKeyword,
                                                                    new ObjectExpression(
                                                                        new List<BinaryOperatorExpression>
                                                                        {
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "shift",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BooleanExpression(
                                                                                    true
                                                                                )
                                                                            ),
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "key",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BinaryOperatorExpression(
                                                                                    new StringExpression(
                                                                                        "'2'"
                                                                                    ),
                                                                                    AphidTokenType.PipelineOperator,
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "conv",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "ConvertFromString",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    )
                                                                                )
                                                                            ),
                                                                        },
                                                                        null
                                                                    ),
                                                                    false
                                                                ),
                                                            },
                                                            null
                                                        ),
                                                        new IfExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "c",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.EqualityOperator,
                                                                new StringExpression(
                                                                    "'#'"
                                                                )
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new UnaryOperatorExpression(
                                                                    AphidTokenType.retKeyword,
                                                                    new ObjectExpression(
                                                                        new List<BinaryOperatorExpression>
                                                                        {
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "shift",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BooleanExpression(
                                                                                    true
                                                                                )
                                                                            ),
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "key",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BinaryOperatorExpression(
                                                                                    new StringExpression(
                                                                                        "'3'"
                                                                                    ),
                                                                                    AphidTokenType.PipelineOperator,
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "conv",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "ConvertFromString",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    )
                                                                                )
                                                                            ),
                                                                        },
                                                                        null
                                                                    ),
                                                                    false
                                                                ),
                                                            },
                                                            null
                                                        ),
                                                        new IfExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "c",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.EqualityOperator,
                                                                new StringExpression(
                                                                    "'$'"
                                                                )
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new UnaryOperatorExpression(
                                                                    AphidTokenType.retKeyword,
                                                                    new ObjectExpression(
                                                                        new List<BinaryOperatorExpression>
                                                                        {
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "shift",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BooleanExpression(
                                                                                    true
                                                                                )
                                                                            ),
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "key",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BinaryOperatorExpression(
                                                                                    new StringExpression(
                                                                                        "'4'"
                                                                                    ),
                                                                                    AphidTokenType.PipelineOperator,
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "conv",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "ConvertFromString",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    )
                                                                                )
                                                                            ),
                                                                        },
                                                                        null
                                                                    ),
                                                                    false
                                                                ),
                                                            },
                                                            null
                                                        ),
                                                        new IfExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "c",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.EqualityOperator,
                                                                new StringExpression(
                                                                    "'%'"
                                                                )
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new UnaryOperatorExpression(
                                                                    AphidTokenType.retKeyword,
                                                                    new ObjectExpression(
                                                                        new List<BinaryOperatorExpression>
                                                                        {
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "shift",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BooleanExpression(
                                                                                    true
                                                                                )
                                                                            ),
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "key",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BinaryOperatorExpression(
                                                                                    new StringExpression(
                                                                                        "'5'"
                                                                                    ),
                                                                                    AphidTokenType.PipelineOperator,
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "conv",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "ConvertFromString",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    )
                                                                                )
                                                                            ),
                                                                        },
                                                                        null
                                                                    ),
                                                                    false
                                                                ),
                                                            },
                                                            null
                                                        ),
                                                        new IfExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "c",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.EqualityOperator,
                                                                new StringExpression(
                                                                    "'^'"
                                                                )
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new UnaryOperatorExpression(
                                                                    AphidTokenType.retKeyword,
                                                                    new ObjectExpression(
                                                                        new List<BinaryOperatorExpression>
                                                                        {
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "shift",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BooleanExpression(
                                                                                    true
                                                                                )
                                                                            ),
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "key",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BinaryOperatorExpression(
                                                                                    new StringExpression(
                                                                                        "'6'"
                                                                                    ),
                                                                                    AphidTokenType.PipelineOperator,
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "conv",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "ConvertFromString",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    )
                                                                                )
                                                                            ),
                                                                        },
                                                                        null
                                                                    ),
                                                                    false
                                                                ),
                                                            },
                                                            null
                                                        ),
                                                        new IfExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "c",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.EqualityOperator,
                                                                new StringExpression(
                                                                    "'&'"
                                                                )
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new UnaryOperatorExpression(
                                                                    AphidTokenType.retKeyword,
                                                                    new ObjectExpression(
                                                                        new List<BinaryOperatorExpression>
                                                                        {
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "shift",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BooleanExpression(
                                                                                    true
                                                                                )
                                                                            ),
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "key",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BinaryOperatorExpression(
                                                                                    new StringExpression(
                                                                                        "'7'"
                                                                                    ),
                                                                                    AphidTokenType.PipelineOperator,
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "conv",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "ConvertFromString",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    )
                                                                                )
                                                                            ),
                                                                        },
                                                                        null
                                                                    ),
                                                                    false
                                                                ),
                                                            },
                                                            null
                                                        ),
                                                        new IfExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "c",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.EqualityOperator,
                                                                new StringExpression(
                                                                    "'*'"
                                                                )
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new UnaryOperatorExpression(
                                                                    AphidTokenType.retKeyword,
                                                                    new ObjectExpression(
                                                                        new List<BinaryOperatorExpression>
                                                                        {
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "shift",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BooleanExpression(
                                                                                    true
                                                                                )
                                                                            ),
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "key",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BinaryOperatorExpression(
                                                                                    new StringExpression(
                                                                                        "'8'"
                                                                                    ),
                                                                                    AphidTokenType.PipelineOperator,
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "conv",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "ConvertFromString",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    )
                                                                                )
                                                                            ),
                                                                        },
                                                                        null
                                                                    ),
                                                                    false
                                                                ),
                                                            },
                                                            null
                                                        ),
                                                        new IfExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "c",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.EqualityOperator,
                                                                new StringExpression(
                                                                    "'('"
                                                                )
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new UnaryOperatorExpression(
                                                                    AphidTokenType.retKeyword,
                                                                    new ObjectExpression(
                                                                        new List<BinaryOperatorExpression>
                                                                        {
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "shift",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BooleanExpression(
                                                                                    true
                                                                                )
                                                                            ),
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "key",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BinaryOperatorExpression(
                                                                                    new StringExpression(
                                                                                        "'9'"
                                                                                    ),
                                                                                    AphidTokenType.PipelineOperator,
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "conv",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "ConvertFromString",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    )
                                                                                )
                                                                            ),
                                                                        },
                                                                        null
                                                                    ),
                                                                    false
                                                                ),
                                                            },
                                                            null
                                                        ),
                                                        new IfExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "c",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.EqualityOperator,
                                                                new StringExpression(
                                                                    "')'"
                                                                )
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new UnaryOperatorExpression(
                                                                    AphidTokenType.retKeyword,
                                                                    new ObjectExpression(
                                                                        new List<BinaryOperatorExpression>
                                                                        {
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "shift",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BooleanExpression(
                                                                                    true
                                                                                )
                                                                            ),
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "key",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BinaryOperatorExpression(
                                                                                    new StringExpression(
                                                                                        "'0'"
                                                                                    ),
                                                                                    AphidTokenType.PipelineOperator,
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "conv",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "ConvertFromString",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    )
                                                                                )
                                                                            ),
                                                                        },
                                                                        null
                                                                    ),
                                                                    false
                                                                ),
                                                            },
                                                            null
                                                        ),
                                                        new IfExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "c",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.EqualityOperator,
                                                                new StringExpression(
                                                                    "'_'"
                                                                )
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new UnaryOperatorExpression(
                                                                    AphidTokenType.retKeyword,
                                                                    new ObjectExpression(
                                                                        new List<BinaryOperatorExpression>
                                                                        {
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "shift",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BooleanExpression(
                                                                                    true
                                                                                )
                                                                            ),
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "key",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BinaryOperatorExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "OemMinus",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    AphidTokenType.PipelineOperator,
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "conv",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "ConvertFromString",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    )
                                                                                )
                                                                            ),
                                                                        },
                                                                        null
                                                                    ),
                                                                    false
                                                                ),
                                                            },
                                                            null
                                                        ),
                                                        new IfExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "c",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.EqualityOperator,
                                                                new StringExpression(
                                                                    "'='"
                                                                )
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new UnaryOperatorExpression(
                                                                    AphidTokenType.retKeyword,
                                                                    new ObjectExpression(
                                                                        new List<BinaryOperatorExpression>
                                                                        {
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "shift",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BooleanExpression(
                                                                                    false
                                                                                )
                                                                            ),
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "key",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BinaryOperatorExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "OemPlus",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    AphidTokenType.PipelineOperator,
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "conv",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "ConvertFromString",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    )
                                                                                )
                                                                            ),
                                                                        },
                                                                        null
                                                                    ),
                                                                    false
                                                                ),
                                                            },
                                                            null
                                                        ),
                                                        new IfExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "c",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.EqualityOperator,
                                                                new StringExpression(
                                                                    "'{'"
                                                                )
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new UnaryOperatorExpression(
                                                                    AphidTokenType.retKeyword,
                                                                    new ObjectExpression(
                                                                        new List<BinaryOperatorExpression>
                                                                        {
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "shift",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BooleanExpression(
                                                                                    true
                                                                                )
                                                                            ),
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "key",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BinaryOperatorExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "OemOpenBrackets",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    AphidTokenType.PipelineOperator,
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "conv",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "ConvertFromString",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    )
                                                                                )
                                                                            ),
                                                                        },
                                                                        null
                                                                    ),
                                                                    false
                                                                ),
                                                            },
                                                            null
                                                        ),
                                                        new IfExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "c",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.EqualityOperator,
                                                                new StringExpression(
                                                                    "'}'"
                                                                )
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new UnaryOperatorExpression(
                                                                    AphidTokenType.retKeyword,
                                                                    new ObjectExpression(
                                                                        new List<BinaryOperatorExpression>
                                                                        {
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "shift",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BooleanExpression(
                                                                                    true
                                                                                )
                                                                            ),
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "key",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BinaryOperatorExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "OemCloseBrackets",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    AphidTokenType.PipelineOperator,
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "conv",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "ConvertFromString",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    )
                                                                                )
                                                                            ),
                                                                        },
                                                                        null
                                                                    ),
                                                                    false
                                                                ),
                                                            },
                                                            null
                                                        ),
                                                        new IfExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "c",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.EqualityOperator,
                                                                new StringExpression(
                                                                    "'|'"
                                                                )
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new UnaryOperatorExpression(
                                                                    AphidTokenType.retKeyword,
                                                                    new ObjectExpression(
                                                                        new List<BinaryOperatorExpression>
                                                                        {
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "shift",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BooleanExpression(
                                                                                    true
                                                                                )
                                                                            ),
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "key",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BinaryOperatorExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "OemPipe",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    AphidTokenType.PipelineOperator,
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "conv",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "ConvertFromString",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    )
                                                                                )
                                                                            ),
                                                                        },
                                                                        null
                                                                    ),
                                                                    false
                                                                ),
                                                            },
                                                            null
                                                        ),
                                                        new IfExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "c",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.EqualityOperator,
                                                                new StringExpression(
                                                                    "':'"
                                                                )
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new UnaryOperatorExpression(
                                                                    AphidTokenType.retKeyword,
                                                                    new ObjectExpression(
                                                                        new List<BinaryOperatorExpression>
                                                                        {
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "shift",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BooleanExpression(
                                                                                    true
                                                                                )
                                                                            ),
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "key",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BinaryOperatorExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "OemSemicolon",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    AphidTokenType.PipelineOperator,
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "conv",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "ConvertFromString",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    )
                                                                                )
                                                                            ),
                                                                        },
                                                                        null
                                                                    ),
                                                                    false
                                                                ),
                                                            },
                                                            null
                                                        ),
                                                        new IfExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "c",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.EqualityOperator,
                                                                new StringExpression(
                                                                    "'\"'"
                                                                )
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new UnaryOperatorExpression(
                                                                    AphidTokenType.retKeyword,
                                                                    new ObjectExpression(
                                                                        new List<BinaryOperatorExpression>
                                                                        {
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "shift",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BooleanExpression(
                                                                                    true
                                                                                )
                                                                            ),
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "key",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BinaryOperatorExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "OemQuotes",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    AphidTokenType.PipelineOperator,
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "conv",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "ConvertFromString",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    )
                                                                                )
                                                                            ),
                                                                        },
                                                                        null
                                                                    ),
                                                                    false
                                                                ),
                                                            },
                                                            null
                                                        ),
                                                        new IfExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "c",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.EqualityOperator,
                                                                new StringExpression(
                                                                    "'<'"
                                                                )
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new UnaryOperatorExpression(
                                                                    AphidTokenType.retKeyword,
                                                                    new ObjectExpression(
                                                                        new List<BinaryOperatorExpression>
                                                                        {
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "shift",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BooleanExpression(
                                                                                    true
                                                                                )
                                                                            ),
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "key",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BinaryOperatorExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "OemComma",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    AphidTokenType.PipelineOperator,
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "conv",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "ConvertFromString",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    )
                                                                                )
                                                                            ),
                                                                        },
                                                                        null
                                                                    ),
                                                                    false
                                                                ),
                                                            },
                                                            null
                                                        ),
                                                        new IfExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "c",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.EqualityOperator,
                                                                new StringExpression(
                                                                    "'>'"
                                                                )
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new UnaryOperatorExpression(
                                                                    AphidTokenType.retKeyword,
                                                                    new ObjectExpression(
                                                                        new List<BinaryOperatorExpression>
                                                                        {
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "shift",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BooleanExpression(
                                                                                    true
                                                                                )
                                                                            ),
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "key",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BinaryOperatorExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "OemPeriod",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    AphidTokenType.PipelineOperator,
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "conv",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "ConvertFromString",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    )
                                                                                )
                                                                            ),
                                                                        },
                                                                        null
                                                                    ),
                                                                    false
                                                                ),
                                                            },
                                                            null
                                                        ),
                                                        new IfExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "c",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.EqualityOperator,
                                                                new StringExpression(
                                                                    "'?'"
                                                                )
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new UnaryOperatorExpression(
                                                                    AphidTokenType.retKeyword,
                                                                    new ObjectExpression(
                                                                        new List<BinaryOperatorExpression>
                                                                        {
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "shift",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BooleanExpression(
                                                                                    true
                                                                                )
                                                                            ),
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "key",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BinaryOperatorExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "OemQuestion",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    AphidTokenType.PipelineOperator,
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "conv",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "ConvertFromString",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    )
                                                                                )
                                                                            ),
                                                                        },
                                                                        null
                                                                    ),
                                                                    false
                                                                ),
                                                            },
                                                            null
                                                        ),
                                                        new IfExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "c",
                                                                    _IdentifierExpressions
                                                                ),
                                                                AphidTokenType.EqualityOperator,
                                                                new StringExpression(
                                                                    "'~'"
                                                                )
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new UnaryOperatorExpression(
                                                                    AphidTokenType.retKeyword,
                                                                    new ObjectExpression(
                                                                        new List<BinaryOperatorExpression>
                                                                        {
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "shift",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BooleanExpression(
                                                                                    true
                                                                                )
                                                                            ),
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "key",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.ColonOperator,
                                                                                new BinaryOperatorExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "OemTilde",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    AphidTokenType.PipelineOperator,
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "conv",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "ConvertFromString",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    )
                                                                                )
                                                                            ),
                                                                        },
                                                                        null
                                                                    ),
                                                                    false
                                                                ),
                                                            },
                                                            null
                                                        ),
                                                        new UnaryOperatorExpression(
                                                            AphidTokenType.retKeyword,
                                                            new ObjectExpression(
                                                                new List<BinaryOperatorExpression>
                                                                {
                                                                    new BinaryOperatorExpression(
                                                                        new IdentifierExpression(
                                                                            "shift",
                                                                            _IdentifierExpressions
                                                                        ),
                                                                        AphidTokenType.ColonOperator,
                                                                        new BinaryOperatorExpression(
                                                                            new IdentifierExpression(
                                                                                "c",
                                                                                _IdentifierExpressions
                                                                            ),
                                                                            AphidTokenType.PipelineOperator,
                                                                            new BinaryOperatorExpression(
                                                                                new IdentifierExpression(
                                                                                    "Char",
                                                                                    _IdentifierExpressions
                                                                                ),
                                                                                AphidTokenType.MemberOperator,
                                                                                new IdentifierExpression(
                                                                                    "IsUpper",
                                                                                    _IdentifierExpressions
                                                                                )
                                                                            )
                                                                        )
                                                                    ),
                                                                    new BinaryOperatorExpression(
                                                                        new IdentifierExpression(
                                                                            "key",
                                                                            _IdentifierExpressions
                                                                        ),
                                                                        AphidTokenType.ColonOperator,
                                                                        new PatternMatchingExpression(
                                                                            new IdentifierExpression(
                                                                                "c",
                                                                                _IdentifierExpressions
                                                                            ),
                                                                            new List<PatternExpression>
                                                                            {
                                                                                new PatternExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "Add",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    new List<AphidExpression>
                                                                                    {
                                                                                        new StringExpression(
                                                                                            "'+'"
                                                                                        ),
                                                                                    }
                                                                                ),
                                                                                new PatternExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "Decimal",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    new List<AphidExpression>
                                                                                    {
                                                                                        new StringExpression(
                                                                                            "'.'"
                                                                                        ),
                                                                                    }
                                                                                ),
                                                                                new PatternExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "Divide",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    new List<AphidExpression>
                                                                                    {
                                                                                        new StringExpression(
                                                                                            "'/'"
                                                                                        ),
                                                                                    }
                                                                                ),
                                                                                new PatternExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "Multiply",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    new List<AphidExpression>
                                                                                    {
                                                                                        new StringExpression(
                                                                                            "'*'"
                                                                                        ),
                                                                                    }
                                                                                ),
                                                                                new PatternExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "OemBackslash",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    new List<AphidExpression>
                                                                                    {
                                                                                        new StringExpression(
                                                                                            "'\\\\'"
                                                                                        ),
                                                                                    }
                                                                                ),
                                                                                new PatternExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "OemCloseBrackets",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    new List<AphidExpression>
                                                                                    {
                                                                                        new StringExpression(
                                                                                            "']'"
                                                                                        ),
                                                                                    }
                                                                                ),
                                                                                new PatternExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "OemSemicolon",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    new List<AphidExpression>
                                                                                    {
                                                                                        new StringExpression(
                                                                                            "';'"
                                                                                        ),
                                                                                    }
                                                                                ),
                                                                                new PatternExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "OemQuotes",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    new List<AphidExpression>
                                                                                    {
                                                                                        new StringExpression(
                                                                                            "'\\''"
                                                                                        ),
                                                                                    }
                                                                                ),
                                                                                new PatternExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "OemComma",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    new List<AphidExpression>
                                                                                    {
                                                                                        new StringExpression(
                                                                                            "','"
                                                                                        ),
                                                                                    }
                                                                                ),
                                                                                new PatternExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "OemMinus",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    new List<AphidExpression>
                                                                                    {
                                                                                        new StringExpression(
                                                                                            "'-'"
                                                                                        ),
                                                                                    }
                                                                                ),
                                                                                new PatternExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "OemOpenBrackets",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    new List<AphidExpression>
                                                                                    {
                                                                                        new StringExpression(
                                                                                            "'['"
                                                                                        ),
                                                                                    }
                                                                                ),
                                                                                new PatternExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "OemPeriod",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    new List<AphidExpression>
                                                                                    {
                                                                                        new StringExpression(
                                                                                            "'.'"
                                                                                        ),
                                                                                    }
                                                                                ),
                                                                                new PatternExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "OemPipe",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    new List<AphidExpression>
                                                                                    {
                                                                                        new StringExpression(
                                                                                            "'|'"
                                                                                        ),
                                                                                    }
                                                                                ),
                                                                                new PatternExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "OemPlus",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    new List<AphidExpression>
                                                                                    {
                                                                                        new StringExpression(
                                                                                            "'+'"
                                                                                        ),
                                                                                    }
                                                                                ),
                                                                                new PatternExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "OemQuestion",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    new List<AphidExpression>
                                                                                    {
                                                                                        new StringExpression(
                                                                                            "'/'"
                                                                                        ),
                                                                                    }
                                                                                ),
                                                                                new PatternExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "Enter",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    new List<AphidExpression>
                                                                                    {
                                                                                        new StringExpression(
                                                                                            "'\\n'"
                                                                                        ),
                                                                                    }
                                                                                ),
                                                                                new PatternExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "Space",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    new List<AphidExpression>
                                                                                    {
                                                                                        new StringExpression(
                                                                                            "' '"
                                                                                        ),
                                                                                    }
                                                                                ),
                                                                                new PatternExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "Tab",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    new List<AphidExpression>
                                                                                    {
                                                                                        new StringExpression(
                                                                                            "'\\t'"
                                                                                        ),
                                                                                    }
                                                                                ),
                                                                                new PatternExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "Key",
                                                                                            _IdentifierExpressions
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "OemTilde",
                                                                                            _IdentifierExpressions
                                                                                        )
                                                                                    ),
                                                                                    new List<AphidExpression>
                                                                                    {
                                                                                        new StringExpression(
                                                                                            "'`'"
                                                                                        ),
                                                                                    }
                                                                                ),
                                                                                new PatternExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new ImplicitArgumentExpression(
                                                                                            AphidTokenType.ImplicitArgumentOperator
                                                                                        ),
                                                                                        AphidTokenType.PipelineOperator,
                                                                                        new BinaryOperatorExpression(
                                                                                            new IdentifierExpression(
                                                                                                "conv",
                                                                                                _IdentifierExpressions
                                                                                            ),
                                                                                            AphidTokenType.MemberOperator,
                                                                                            new IdentifierExpression(
                                                                                                "ConvertFromString",
                                                                                                _IdentifierExpressions
                                                                                            )
                                                                                        )
                                                                                    ),
                                                                                    _AphidExpressions
                                                                                ),
                                                                            }
                                                                        )
                                                                    ),
                                                                },
                                                                null
                                                            ),
                                                            false
                                                        ),
                                                    }
                                                )
                                            ),
                                        }
                                    ),
                                    _AphidExpressions
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
                    
                    private static readonly List<AphidExpression> _AphidExpressions = new List<AphidExpression>();
                    

                    
                    private static readonly NullExpression _NullExpression = new NullExpression();
                    
                    private static readonly ThisExpression _ThisExpression = new ThisExpression();
                    
                    
                
                }
            }
            

