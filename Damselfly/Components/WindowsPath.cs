using global::Components.Aphid.Parser;
using global::Components.Aphid.Interpreter;

namespace Damselfly.Components
{


    public partial class WindowsPath
    {

        private static SearchDelegate _Search;

        public static SearchDelegate Search
        {
            get
            {
                if ((WindowsPath._Search == null))
                {
                    new AphidInterpreter().Interpret(AphidCompilerResources.ByteCode_d0922cf98d4040d5fec7db5ca0eb57c2());
                }
                return WindowsPath._Search;
            }
            set
            {
                WindowsPath._Search = value;
            }
        }

        public delegate string SearchDelegate(string path);
    }
}

namespace Damselfly.Components
{


    public partial class WindowsPath
    {

        private static PrepareFilenameDelegate _PrepareFilename;

        public static PrepareFilenameDelegate PrepareFilename
        {
            get
            {
                if ((WindowsPath._PrepareFilename == null))
                {
                    new AphidInterpreter().Interpret(AphidCompilerResources.ByteCode_d0922cf98d4040d5fec7db5ca0eb57c2());
                }
                return WindowsPath._PrepareFilename;
            }
            set
            {
                WindowsPath._PrepareFilename = value;
            }
        }

        public delegate string PrepareFilenameDelegate(string cmd);
    }
}

namespace Damselfly.Components
{


    public partial class WindowsPath
    {

        private static IsValidPathDelegate _IsValidPath;

        public static IsValidPathDelegate IsValidPath
        {
            get
            {
                if ((WindowsPath._IsValidPath == null))
                {
                    new AphidInterpreter().Interpret(AphidCompilerResources.ByteCode_d0922cf98d4040d5fec7db5ca0eb57c2());
                }
                return WindowsPath._IsValidPath;
            }
            set
            {
                WindowsPath._IsValidPath = value;
            }
        }

        public delegate bool IsValidPathDelegate(string path);
    }
}

namespace Damselfly.Components
{


    public partial class WindowsPath
    {

        private static IsValidFileNameDelegate _IsValidFileName;

        public static IsValidFileNameDelegate IsValidFileName
        {
            get
            {
                if ((WindowsPath._IsValidFileName == null))
                {
                    new AphidInterpreter().Interpret(AphidCompilerResources.ByteCode_d0922cf98d4040d5fec7db5ca0eb57c2());
                }
                return WindowsPath._IsValidFileName;
            }
            set
            {
                WindowsPath._IsValidFileName = value;
            }
        }

        public delegate bool IsValidFileNameDelegate(string fileName);
    }
}

namespace Damselfly.Components
{


    public partial class WindowsPath
    {

        private static JitCompileDelegate _JitCompile;

        public static JitCompileDelegate JitCompile
        {
            get
            {
                if ((WindowsPath._JitCompile == null))
                {
                    new AphidInterpreter().Interpret(AphidCompilerResources.ByteCode_d0922cf98d4040d5fec7db5ca0eb57c2());
                }
                return WindowsPath._JitCompile;
            }
            set
            {
                WindowsPath._JitCompile = value;
            }
        }

        public delegate bool JitCompileDelegate();
    }
}


namespace Damselfly.Components
{
    /* Test */
    using global::Components.Aphid.Lexer;
    using global::Components.Aphid.Parser;
    using System;
    using System.Collections.Generic;

    public static partial class AphidCompilerResources
    {

        /*fmt*/

        public static List<AphidExpression> ByteCode_d0922cf98d4040d5fec7db5ca0eb57c2() =>
            ByteCode_d0922cf98d4040d5fec7db5ca0eb57c2Lazy.Value;

        private static readonly List<AphidExpression> _empty = new List<AphidExpression>();
        private static readonly List<IdentifierExpression> _emptyId = new List<IdentifierExpression>();

        private static System.Lazy<List<AphidExpression>> ByteCode_d0922cf98d4040d5fec7db5ca0eb57c2Lazy =>
            new System.Lazy<List<AphidExpression>>(() =>
                new List<AphidExpression>
{
    new LoadScriptExpression(
        new StringExpression(
            "'Std'"
        )
    ),
    new LoadScriptExpression(
        new StringExpression(
            "'Meta/Code/Compiler'"
        )
    ),
    new UnaryOperatorExpression(
        AphidTokenType.usingKeyword,
        new IdentifierExpression(
            "Components",
            _emptyId
        ),
        false
    ),
    new UnaryOperatorExpression(
        AphidTokenType.usingKeyword,
        new BinaryOperatorExpression(
            new IdentifierExpression(
                "Damselfly",
                _emptyId
            ),
            AphidTokenType.MemberOperator,
            new IdentifierExpression(
                "Components",
                _emptyId
            )
        ),
        false
    ),
    new UnaryOperatorExpression(
        AphidTokenType.usingKeyword,
        new IdentifierExpression(
            "System",
            _emptyId
        ),
        false
    ),
    new BinaryOperatorExpression(
        new IdentifierExpression(
            "expand",
            new List<IdentifierExpression>
            {
                new IdentifierExpression(
                    "var",
                    _emptyId
                ),
            }
        ),
        AphidTokenType.AssignmentOperator,
        new FunctionExpression(
            new List<AphidExpression>
            {
                new IdentifierExpression(
                    "p",
                    _emptyId
                ),
            },
            new List<AphidExpression>
            {
                new UnaryOperatorExpression(
                    AphidTokenType.retKeyword,
                    new PatternMatchingExpression(
                        new BinaryOperatorExpression(
                            new IdentifierExpression(
                                "t",
                                new List<IdentifierExpression>
                                {
                                    new IdentifierExpression(
                                        "var",
                                        _emptyId
                                    ),
                                }
                            ),
                            AphidTokenType.AssignmentOperator,
                            new BinaryOperatorExpression(
                                new IdentifierExpression(
                                    "p",
                                    _emptyId
                                ),
                                AphidTokenType.PipelineOperator,
                                new BinaryOperatorExpression(
                                    new IdentifierExpression(
                                        "Environment",
                                        _emptyId
                                    ),
                                    AphidTokenType.MemberOperator,
                                    new IdentifierExpression(
                                        "ExpandEnvironmentVariables",
                                        _emptyId
                                    )
                                )
                            )
                        ),
                        new List<PatternExpression>
                        {
                            new PatternExpression(
                                new IdentifierExpression(
                                    "p",
                                    _emptyId
                                ),
                                new List<AphidExpression>
                                {
                                    new IdentifierExpression(
                                        "p",
                                        _emptyId
                                    ),
                                }
                            ),
                            new PatternExpression(
                                new CallExpression(
                                    new IdentifierExpression(
                                        "expand",
                                        _emptyId
                                    ),
                                    new List<AphidExpression>
                                    {
                                        new IdentifierExpression(
                                            "t",
                                            _emptyId
                                        ),
                                    }
                                ),
                                new List<AphidExpression>
                                {
                                }
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
            "paths",
            new List<IdentifierExpression>
            {
                new IdentifierExpression(
                    "var",
                    _emptyId
                ),
            }
        ),
        AphidTokenType.AssignmentOperator,
        new BinaryOperatorExpression(
            new BinaryOperatorExpression(
                new StringExpression(
                    "'%PATH%'"
                ),
                AphidTokenType.PipelineOperator,
                new IdentifierExpression(
                    "expand",
                    _emptyId
                )
            ),
            AphidTokenType.PipelineOperator,
            new FunctionExpression(
                new List<AphidExpression>
                {
                },
                new List<AphidExpression>
                {
                    new UnaryOperatorExpression(
                        AphidTokenType.retKeyword,
                        new UnaryOperatorExpression(
                            AphidTokenType.DistinctOperator,
                            new BinaryOperatorExpression(
                                new BinaryOperatorExpression(
                                    new CallExpression(
                                        new BinaryOperatorExpression(
                                            new ImplicitArgumentExpression(
                                                AphidTokenType.ImplicitArgumentOperator
                                            ),
                                            AphidTokenType.MemberOperator,
                                            new IdentifierExpression(
                                                "Split",
                                                _emptyId
                                            )
                                        ),
                                        new List<AphidExpression>
                                        {
                                            new StringExpression(
                                                "';'"
                                            ),
                                        }
                                    ),
                                    AphidTokenType.SelectOperator,
                                    new FunctionExpression(
                                        new List<AphidExpression>
                                        {
                                        },
                                        new List<AphidExpression>
                                        {
                                            new UnaryOperatorExpression(
                                                AphidTokenType.retKeyword,
                                                new CallExpression(
                                                    new BinaryOperatorExpression(
                                                        new ImplicitArgumentExpression(
                                                            AphidTokenType.ImplicitArgumentOperator
                                                        ),
                                                        AphidTokenType.MemberOperator,
                                                        new IdentifierExpression(
                                                            "TrimEnd",
                                                            _emptyId
                                                        )
                                                    ),
                                                    new List<AphidExpression>
                                                    {
                                                        new StringExpression(
                                                            "'\\\\'"
                                                        ),
                                                    }
                                                ),
                                                false
                                            ),
                                        }
                                    )
                                ),
                                AphidTokenType.WhereOperator,
                                new FunctionExpression(
                                    new List<AphidExpression>
                                    {
                                        new IdentifierExpression(
                                            "___p_op_0",
                                            _emptyId
                                        ),
                                    },
                                    new List<AphidExpression>
                                    {
                                        new UnaryOperatorExpression(
                                            AphidTokenType.retKeyword,
                                            new BinaryOperatorExpression(
                                                new IdentifierExpression(
                                                    "___p_op_0",
                                                    _emptyId
                                                ),
                                                AphidTokenType.NotEqualOperator,
                                                new StringExpression(
                                                    "''"
                                                )
                                            ),
                                            false
                                        ),
                                    }
                                )
                            ),
                            false
                        ),
                        false
                    ),
                }
            )
        )
    ),
    new BinaryOperatorExpression(
        new IdentifierExpression(
            "exts",
            new List<IdentifierExpression>
            {
                new IdentifierExpression(
                    "var",
                    _emptyId
                ),
            }
        ),
        AphidTokenType.AssignmentOperator,
        new ArrayExpression(
            new List<AphidExpression>
            {
                new StringExpression(
                    "''"
                ),
                new StringExpression(
                    "'.exe'"
                ),
                new StringExpression(
                    "'.cmd'"
                ),
                new StringExpression(
                    "'.bat'"
                ),
            }
        )
    ),
    new BinaryOperatorExpression(
        new BinaryOperatorExpression(
            new IdentifierExpression(
                "WindowsPath",
                new List<IdentifierExpression>
                {
                    new IdentifierExpression(
                        "export",
                        _emptyId
                    ),
                    new IdentifierExpression(
                        "string",
                        _emptyId
                    ),
                }
            ),
            AphidTokenType.MemberOperator,
            new IdentifierExpression(
                "Search",
                _emptyId
            )
        ),
        AphidTokenType.AssignmentOperator,
        new FunctionExpression(
            new List<AphidExpression>
            {
                new IdentifierExpression(
                    "path",
                    new List<IdentifierExpression>
                    {
                        new IdentifierExpression(
                            "string",
                            _emptyId
                        ),
                    }
                ),
            },
            new List<AphidExpression>
            {
                new UnaryOperatorExpression(
                    AphidTokenType.retKeyword,
                    new BinaryOperatorExpression(
                        new BinaryOperatorExpression(
                            new IdentifierExpression(
                                "paths",
                                _emptyId
                            ),
                            AphidTokenType.SelectManyOperator,
                            new FunctionExpression(
                                new List<AphidExpression>
                                {
                                    new IdentifierExpression(
                                        "p",
                                        _emptyId
                                    ),
                                },
                                new List<AphidExpression>
                                {
                                    new UnaryOperatorExpression(
                                        AphidTokenType.retKeyword,
                                        new BinaryOperatorExpression(
                                            new IdentifierExpression(
                                                "exts",
                                                _emptyId
                                            ),
                                            AphidTokenType.SelectOperator,
                                            new FunctionExpression(
                                                new List<AphidExpression>
                                                {
                                                    new IdentifierExpression(
                                                        "e",
                                                        _emptyId
                                                    ),
                                                },
                                                new List<AphidExpression>
                                                {
                                                    new UnaryOperatorExpression(
                                                        AphidTokenType.retKeyword,
                                                        new CallExpression(
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "Path",
                                                                    _emptyId
                                                                ),
                                                                AphidTokenType.MemberOperator,
                                                                new IdentifierExpression(
                                                                    "Combine",
                                                                    _emptyId
                                                                )
                                                            ),
                                                            new List<AphidExpression>
                                                            {
                                                                new IdentifierExpression(
                                                                    "p",
                                                                    _emptyId
                                                                ),
                                                                new BinaryOperatorExpression(
                                                                    new IdentifierExpression(
                                                                        "path",
                                                                        _emptyId
                                                                    ),
                                                                    AphidTokenType.AdditionOperator,
                                                                    new IdentifierExpression(
                                                                        "e",
                                                                        _emptyId
                                                                    )
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
                        AphidTokenType.PipelineOperator,
                        new PartialFunctionExpression(
                            new CallExpression(
                                new BinaryOperatorExpression(
                                    new IdentifierExpression(
                                        "aq",
                                        _emptyId
                                    ),
                                    AphidTokenType.MemberOperator,
                                    new IdentifierExpression(
                                        "first",
                                        _emptyId
                                    )
                                ),
                                new List<AphidExpression>
                                {
                                    new BinaryOperatorExpression(
                                        new IdentifierExpression(
                                            "File",
                                            _emptyId
                                        ),
                                        AphidTokenType.MemberOperator,
                                        new IdentifierExpression(
                                            "Exists",
                                            _emptyId
                                        )
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
        new BinaryOperatorExpression(
            new IdentifierExpression(
                "WindowsPath",
                new List<IdentifierExpression>
                {
                    new IdentifierExpression(
                        "export",
                        _emptyId
                    ),
                    new IdentifierExpression(
                        "string",
                        _emptyId
                    ),
                }
            ),
            AphidTokenType.MemberOperator,
            new IdentifierExpression(
                "PrepareFilename",
                _emptyId
            )
        ),
        AphidTokenType.AssignmentOperator,
        new FunctionExpression(
            new List<AphidExpression>
            {
                new IdentifierExpression(
                    "cmd",
                    new List<IdentifierExpression>
                    {
                        new IdentifierExpression(
                            "string",
                            _emptyId
                        ),
                    }
                ),
            },
            new List<AphidExpression>
            {
                new UnaryOperatorExpression(
                    AphidTokenType.retKeyword,
                    new TernaryOperatorExpression(
                        AphidTokenType.ConditionalOperator,
                        new BinaryOperatorExpression(
                            new UnaryOperatorExpression(
                                AphidTokenType.NotOperator,
                                new CallExpression(
                                    new BinaryOperatorExpression(
                                        new IdentifierExpression(
                                            "cmd",
                                            _emptyId
                                        ),
                                        AphidTokenType.MemberOperator,
                                        new IdentifierExpression(
                                            "Contains",
                                            _emptyId
                                        )
                                    ),
                                    new List<AphidExpression>
                                    {
                                        new StringExpression(
                                            "' '"
                                        ),
                                    }
                                ),
                                false
                            ),
                            AphidTokenType.AndOperator,
                            new UnaryOperatorExpression(
                                AphidTokenType.NotOperator,
                                new CallExpression(
                                    new BinaryOperatorExpression(
                                        new IdentifierExpression(
                                            "cmd",
                                            _emptyId
                                        ),
                                        AphidTokenType.MemberOperator,
                                        new IdentifierExpression(
                                            "Contains",
                                            _emptyId
                                        )
                                    ),
                                    new List<AphidExpression>
                                    {
                                        new StringExpression(
                                            "'\\t'"
                                        ),
                                    }
                                ),
                                false
                            )
                        ),
                        new IdentifierExpression(
                            "cmd",
                            _emptyId
                        ),
                        new TernaryOperatorExpression(
                            AphidTokenType.ConditionalOperator,
                            new CallExpression(
                                new BinaryOperatorExpression(
                                    new IdentifierExpression(
                                        "Directory",
                                        _emptyId
                                    ),
                                    AphidTokenType.MemberOperator,
                                    new IdentifierExpression(
                                        "Exists",
                                        _emptyId
                                    )
                                ),
                                new List<AphidExpression>
                                {
                                    new IdentifierExpression(
                                        "cmd",
                                        _emptyId
                                    ),
                                }
                            ),
                            new BinaryOperatorExpression(
                                new StringExpression(
                                    "'\"{0}\"'"
                                ),
                                AphidTokenType.CustomOperator214,
                                new ArrayExpression(
                                    new List<AphidExpression>
                                    {
                                        new IdentifierExpression(
                                            "cmd",
                                            _emptyId
                                        ),
                                    }
                                )
                            ),
                            new CallExpression(
                                new IdentifierExpression(
                                    "quoteFilename",
                                    _emptyId
                                ),
                                new List<AphidExpression>
                                {
                                    new IdentifierExpression(
                                        "cmd",
                                        _emptyId
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
            "quoteFilename",
            new List<IdentifierExpression>
            {
                new IdentifierExpression(
                    "var",
                    _emptyId
                ),
            }
        ),
        AphidTokenType.AssignmentOperator,
        new FunctionExpression(
            new List<AphidExpression>
            {
                new IdentifierExpression(
                    "cmd",
                    new List<IdentifierExpression>
                    {
                        new IdentifierExpression(
                            "string",
                            _emptyId
                        ),
                    }
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
                                new IdentifierExpression(
                                    "f",
                                    new List<IdentifierExpression>
                                    {
                                        new IdentifierExpression(
                                            "var",
                                            _emptyId
                                        ),
                                    }
                                ),
                                AphidTokenType.AssignmentOperator,
                                new BinaryOperatorExpression(
                                    new BinaryOperatorExpression(
                                        new BinaryOperatorExpression(
                                            new IdentifierExpression(
                                                "cmd",
                                                _emptyId
                                            ),
                                            AphidTokenType.PipelineOperator,
                                            new BinaryOperatorExpression(
                                                new IdentifierExpression(
                                                    "ArgLexer",
                                                    _emptyId
                                                ),
                                                AphidTokenType.MemberOperator,
                                                new IdentifierExpression(
                                                    "GetTokenInfo",
                                                    _emptyId
                                                )
                                            )
                                        ),
                                        AphidTokenType.SelectOperator,
                                        new FunctionExpression(
                                            new List<AphidExpression>
                                            {
                                                new IdentifierExpression(
                                                    "x",
                                                    _emptyId
                                                ),
                                            },
                                            new List<AphidExpression>
                                            {
                                                new UnaryOperatorExpression(
                                                    AphidTokenType.retKeyword,
                                                    new ObjectExpression(
                                                        new List<BinaryOperatorExpression>
                                                        {
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "token",
                                                                    _emptyId
                                                                ),
                                                                AphidTokenType.ColonOperator,
                                                                new IdentifierExpression(
                                                                    "x",
                                                                    _emptyId
                                                                )
                                                            ),
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "hasArgs",
                                                                    _emptyId
                                                                ),
                                                                AphidTokenType.ColonOperator,
                                                                new BinaryOperatorExpression(
                                                                    new BinaryOperatorExpression(
                                                                        new IdentifierExpression(
                                                                            "x",
                                                                            _emptyId
                                                                        ),
                                                                        AphidTokenType.MemberOperator,
                                                                        new IdentifierExpression(
                                                                            "EndOffset",
                                                                            _emptyId
                                                                        )
                                                                    ),
                                                                    AphidTokenType.LessThanOperator,
                                                                    new BinaryOperatorExpression(
                                                                        new IdentifierExpression(
                                                                            "cmd",
                                                                            _emptyId
                                                                        ),
                                                                        AphidTokenType.MemberOperator,
                                                                        new IdentifierExpression(
                                                                            "Length",
                                                                            _emptyId
                                                                        )
                                                                    )
                                                                )
                                                            ),
                                                            new BinaryOperatorExpression(
                                                                new IdentifierExpression(
                                                                    "path",
                                                                    _emptyId
                                                                ),
                                                                AphidTokenType.ColonOperator,
                                                                new TernaryOperatorExpression(
                                                                    AphidTokenType.ConditionalOperator,
                                                                    new IdentifierExpression(
                                                                        "hasArgs",
                                                                        _emptyId
                                                                    ),
                                                                    new CallExpression(
                                                                        new BinaryOperatorExpression(
                                                                            new IdentifierExpression(
                                                                                "cmd",
                                                                                _emptyId
                                                                            ),
                                                                            AphidTokenType.MemberOperator,
                                                                            new IdentifierExpression(
                                                                                "Remove",
                                                                                _emptyId
                                                                            )
                                                                        ),
                                                                        new List<AphidExpression>
                                                                        {
                                                                            new BinaryOperatorExpression(
                                                                                new BinaryOperatorExpression(
                                                                                    new IdentifierExpression(
                                                                                        "x",
                                                                                        _emptyId
                                                                                    ),
                                                                                    AphidTokenType.MemberOperator,
                                                                                    new IdentifierExpression(
                                                                                        "EndOffset",
                                                                                        _emptyId
                                                                                    )
                                                                                ),
                                                                                AphidTokenType.MinusOperator,
                                                                                new NumberExpression(
                                                                                    1
                                                                                )
                                                                            ),
                                                                        }
                                                                    ),
                                                                    new IdentifierExpression(
                                                                        "cmd",
                                                                        _emptyId
                                                                    )
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
                                    AphidTokenType.PipelineOperator,
                                    new PartialFunctionExpression(
                                        new CallExpression(
                                            new BinaryOperatorExpression(
                                                new IdentifierExpression(
                                                    "aq",
                                                    _emptyId
                                                ),
                                                AphidTokenType.MemberOperator,
                                                new IdentifierExpression(
                                                    "first",
                                                    _emptyId
                                                )
                                            ),
                                            new List<AphidExpression>
                                            {
                                                new FunctionExpression(
                                                    new List<AphidExpression>
                                                    {
                                                        new IdentifierExpression(
                                                            "x",
                                                            _emptyId
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
                                                                        _emptyId
                                                                    ),
                                                                    AphidTokenType.MemberOperator,
                                                                    new IdentifierExpression(
                                                                        "Exists",
                                                                        _emptyId
                                                                    )
                                                                ),
                                                                new List<AphidExpression>
                                                                {
                                                                    new BinaryOperatorExpression(
                                                                        new IdentifierExpression(
                                                                            "x",
                                                                            _emptyId
                                                                        ),
                                                                        AphidTokenType.MemberOperator,
                                                                        new IdentifierExpression(
                                                                            "path",
                                                                            _emptyId
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
                                    )
                                )
                            ),
                            AphidTokenType.NotEqualOperator,
                            new NullExpression(
                            )
                        ),
                        new BinaryOperatorExpression(
                            new StringExpression(
                                "'\"{0}\"{1}'"
                            ),
                            AphidTokenType.CustomOperator214,
                            new ArrayExpression(
                                new List<AphidExpression>
                                {
                                    new BinaryOperatorExpression(
                                        new IdentifierExpression(
                                            "f",
                                            _emptyId
                                        ),
                                        AphidTokenType.MemberOperator,
                                        new IdentifierExpression(
                                            "path",
                                            _emptyId
                                        )
                                    ),
                                    new TernaryOperatorExpression(
                                        AphidTokenType.ConditionalOperator,
                                        new BinaryOperatorExpression(
                                            new IdentifierExpression(
                                                "f",
                                                _emptyId
                                            ),
                                            AphidTokenType.MemberOperator,
                                            new IdentifierExpression(
                                                "hasArgs",
                                                _emptyId
                                            )
                                        ),
                                        new CallExpression(
                                            new BinaryOperatorExpression(
                                                new IdentifierExpression(
                                                    "cmd",
                                                    _emptyId
                                                ),
                                                AphidTokenType.MemberOperator,
                                                new IdentifierExpression(
                                                    "Substring",
                                                    _emptyId
                                                )
                                            ),
                                            new List<AphidExpression>
                                            {
                                                new BinaryOperatorExpression(
                                                    new BinaryOperatorExpression(
                                                        new BinaryOperatorExpression(
                                                            new IdentifierExpression(
                                                                "f",
                                                                _emptyId
                                                            ),
                                                            AphidTokenType.MemberOperator,
                                                            new IdentifierExpression(
                                                                "token",
                                                                _emptyId
                                                            )
                                                        ),
                                                        AphidTokenType.MemberOperator,
                                                        new IdentifierExpression(
                                                            "EndOffset",
                                                            _emptyId
                                                        )
                                                    ),
                                                    AphidTokenType.MinusOperator,
                                                    new NumberExpression(
                                                        1
                                                    )
                                                ),
                                            }
                                        ),
                                        new StringExpression(
                                            "''"
                                        )
                                    ),
                                }
                            )
                        ),
                        new IdentifierExpression(
                            "cmd",
                            _emptyId
                        )
                    ),
                    false
                ),
            }
        )
    ),
    new BinaryOperatorExpression(
        new BinaryOperatorExpression(
            new IdentifierExpression(
                "WindowsPath",
                new List<IdentifierExpression>
                {
                    new IdentifierExpression(
                        "export",
                        _emptyId
                    ),
                    new IdentifierExpression(
                        "bool",
                        _emptyId
                    ),
                }
            ),
            AphidTokenType.MemberOperator,
            new IdentifierExpression(
                "IsValidPath",
                _emptyId
            )
        ),
        AphidTokenType.AssignmentOperator,
        new FunctionExpression(
            new List<AphidExpression>
            {
                new IdentifierExpression(
                    "path",
                    new List<IdentifierExpression>
                    {
                        new IdentifierExpression(
                            "string",
                            _emptyId
                        ),
                    }
                ),
            },
            new List<AphidExpression>
            {
                new UnaryOperatorExpression(
                    AphidTokenType.retKeyword,
                    new UnaryOperatorExpression(
                        AphidTokenType.NotOperator,
                        new BinaryOperatorExpression(
                            new CallExpression(
                                new BinaryOperatorExpression(
                                    new IdentifierExpression(
                                        "Path",
                                        _emptyId
                                    ),
                                    AphidTokenType.MemberOperator,
                                    new IdentifierExpression(
                                        "GetInvalidPathChars",
                                        _emptyId
                                    )
                                ),
                                new List<AphidExpression>
                                {
                                }
                            ),
                            AphidTokenType.AnyOperator,
                            new BinaryOperatorExpression(
                                new IdentifierExpression(
                                    "path",
                                    _emptyId
                                ),
                                AphidTokenType.MemberOperator,
                                new IdentifierExpression(
                                    "Contains",
                                    _emptyId
                                )
                            )
                        ),
                        false
                    ),
                    false
                ),
            }
        )
    ),
    new BinaryOperatorExpression(
        new BinaryOperatorExpression(
            new IdentifierExpression(
                "WindowsPath",
                new List<IdentifierExpression>
                {
                    new IdentifierExpression(
                        "export",
                        _emptyId
                    ),
                    new IdentifierExpression(
                        "bool",
                        _emptyId
                    ),
                }
            ),
            AphidTokenType.MemberOperator,
            new IdentifierExpression(
                "IsValidFileName",
                _emptyId
            )
        ),
        AphidTokenType.AssignmentOperator,
        new FunctionExpression(
            new List<AphidExpression>
            {
                new IdentifierExpression(
                    "fileName",
                    new List<IdentifierExpression>
                    {
                        new IdentifierExpression(
                            "string",
                            _emptyId
                        ),
                    }
                ),
            },
            new List<AphidExpression>
            {
                new UnaryOperatorExpression(
                    AphidTokenType.retKeyword,
                    new UnaryOperatorExpression(
                        AphidTokenType.NotOperator,
                        new BinaryOperatorExpression(
                            new CallExpression(
                                new BinaryOperatorExpression(
                                    new IdentifierExpression(
                                        "Path",
                                        _emptyId
                                    ),
                                    AphidTokenType.MemberOperator,
                                    new IdentifierExpression(
                                        "GetInvalidFileNameChars",
                                        _emptyId
                                    )
                                ),
                                new List<AphidExpression>
                                {
                                }
                            ),
                            AphidTokenType.AnyOperator,
                            new BinaryOperatorExpression(
                                new IdentifierExpression(
                                    "fileName",
                                    _emptyId
                                ),
                                AphidTokenType.MemberOperator,
                                new IdentifierExpression(
                                    "Contains",
                                    _emptyId
                                )
                            )
                        ),
                        false
                    ),
                    false
                ),
            }
        )
    ),
    new BinaryOperatorExpression(
        new BinaryOperatorExpression(
            new IdentifierExpression(
                "WindowsPath",
                new List<IdentifierExpression>
                {
                    new IdentifierExpression(
                        "export",
                        _emptyId
                    ),
                    new IdentifierExpression(
                        "bool",
                        _emptyId
                    ),
                }
            ),
            AphidTokenType.MemberOperator,
            new IdentifierExpression(
                "JitCompile",
                _emptyId
            )
        ),
        AphidTokenType.AssignmentOperator,
        new FunctionExpression(
            new List<AphidExpression>
            {
            },
            new List<AphidExpression>
            {
                new BinaryOperatorExpression(
                    new IdentifierExpression(
                        "setExport",
                        new List<IdentifierExpression>
                        {
                            new IdentifierExpression(
                                "var",
                                _emptyId
                            ),
                        }
                    ),
                    AphidTokenType.AssignmentOperator,
                    new FunctionExpression(
                        new List<AphidExpression>
                        {
                            new IdentifierExpression(
                                "exportMember",
                                _emptyId
                            ),
                            new IdentifierExpression(
                                "clrFunc",
                                _emptyId
                            ),
                        },
                        new List<AphidExpression>
                        {
                            new BinaryOperatorExpression(
                                new IdentifierExpression(
                                    "del",
                                    new List<IdentifierExpression>
                                    {
                                        new IdentifierExpression(
                                            "var",
                                            _emptyId
                                        ),
                                    }
                                ),
                                AphidTokenType.AssignmentOperator,
                                new CallExpression(
                                    new BinaryOperatorExpression(
                                        new ArrayAccessExpression(
                                            new BinaryOperatorExpression(
                                                new IdentifierExpression(
                                                    "clrFunc",
                                                    _emptyId
                                                ),
                                                AphidTokenType.MemberOperator,
                                                new IdentifierExpression(
                                                    "Members",
                                                    _emptyId
                                                )
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
                                            "CreateDelegate",
                                            _emptyId
                                        )
                                    ),
                                    new List<AphidExpression>
                                    {
                                        new ArrayAccessExpression(
                                            new IdentifierExpression(
                                                "WindowsPath",
                                                _emptyId
                                            ),
                                            new List<AphidExpression>
                                            {
                                                new BinaryOperatorExpression(
                                                    new IdentifierExpression(
                                                        "exportName",
                                                        _emptyId
                                                    ),
                                                    AphidTokenType.AdditionOperator,
                                                    new StringExpression(
                                                        "'Delegate'"
                                                    )
                                                ),
                                            }
                                        ),
                                    }
                                )
                            ),
                            new BinaryOperatorExpression(
                                new IdentifierExpression(
                                    "exportMember",
                                    _emptyId
                                ),
                                AphidTokenType.AssignmentOperator,
                                new IdentifierExpression(
                                    "del",
                                    _emptyId
                                )
                            ),
                        }
                    )
                ),
                new CallExpression(
                    new IdentifierExpression(
                        "head",
                        _emptyId
                    ),
                    new List<AphidExpression>
                    {
                        new StringExpression(
                            "'Building'"
                        ),
                    }
                ),
                new BinaryOperatorExpression(
                    new IdentifierExpression(
                        "csUnits",
                        new List<IdentifierExpression>
                        {
                            new IdentifierExpression(
                                "var",
                                _emptyId
                            ),
                        }
                    ),
                    AphidTokenType.AssignmentOperator,
                    new BinaryOperatorExpression(
                        new ArrayExpression(
                            new List<AphidExpression>
                            {
                                new ObjectExpression(
                                    new List<BinaryOperatorExpression>
                                    {
                                        new BinaryOperatorExpression(
                                            new IdentifierExpression(
                                                "name",
                                                _emptyId
                                            ),
                                            AphidTokenType.ColonOperator,
                                            new StringExpression(
                                                "'FileName'"
                                            )
                                        ),
                                        new BinaryOperatorExpression(
                                            new IdentifierExpression(
                                                "func",
                                                _emptyId
                                            ),
                                            AphidTokenType.ColonOperator,
                                            new BinaryOperatorExpression(
                                                new IdentifierExpression(
                                                    "Path",
                                                    _emptyId
                                                ),
                                                AphidTokenType.MemberOperator,
                                                new IdentifierExpression(
                                                    "GetInvalidFileNameChars",
                                                    _emptyId
                                                )
                                            )
                                        ),
                                    },
                                    null
                                ),
                                new ObjectExpression(
                                    new List<BinaryOperatorExpression>
                                    {
                                        new BinaryOperatorExpression(
                                            new IdentifierExpression(
                                                "name",
                                                _emptyId
                                            ),
                                            AphidTokenType.ColonOperator,
                                            new StringExpression(
                                                "'Path'"
                                            )
                                        ),
                                        new BinaryOperatorExpression(
                                            new IdentifierExpression(
                                                "func",
                                                _emptyId
                                            ),
                                            AphidTokenType.ColonOperator,
                                            new BinaryOperatorExpression(
                                                new IdentifierExpression(
                                                    "Path",
                                                    _emptyId
                                                ),
                                                AphidTokenType.MemberOperator,
                                                new IdentifierExpression(
                                                    "GetInvalidPathChars",
                                                    _emptyId
                                                )
                                            )
                                        ),
                                    },
                                    null
                                ),
                            }
                        ),
                        AphidTokenType.SelectOperator,
                        new FunctionExpression(
                            new List<AphidExpression>
                            {
                                new IdentifierExpression(
                                    "s",
                                    _emptyId
                                ),
                            },
                            new List<AphidExpression>
                            {
                                new UnaryOperatorExpression(
                                    AphidTokenType.retKeyword,
                                    new CallExpression(
                                        new BinaryOperatorExpression(
                                            new CallExpression(
                                                new IdentifierExpression(
                                                    "strOut",
                                                    _emptyId
                                                ),
                                                new List<AphidExpression>
                                                {
                                                    new FunctionExpression(
                                                        new List<AphidExpression>
                                                        {
                                                        },
                                                        new List<AphidExpression>
                                                        {
                                                            new GatorCloseExpression(
                                                            ),
                                                            new TextExpression(
                                                                "\r\n            namespace Damselfly.Components\r\n            {\r\n                   public static partial class WindowsPath\r\n                {\r\n                    public static bool IsValid"
                                                            ),
                                                            new GatorEmitExpression(
                                                                new BinaryOperatorExpression(
                                                                    new IdentifierExpression(
                                                                        "s",
                                                                        _emptyId
                                                                    ),
                                                                    AphidTokenType.MemberOperator,
                                                                    new IdentifierExpression(
                                                                        "name",
                                                                        _emptyId
                                                                    )
                                                                )
                                                            ),
                                                            new TextExpression(
                                                                "(string "
                                                            ),
                                                            new GatorEmitExpression(
                                                                new BinaryOperatorExpression(
                                                                    new IdentifierExpression(
                                                                        "localName",
                                                                        new List<IdentifierExpression>
                                                                        {
                                                                            new IdentifierExpression(
                                                                                "var",
                                                                                _emptyId
                                                                            ),
                                                                        }
                                                                    ),
                                                                    AphidTokenType.AssignmentOperator,
                                                                    new BinaryOperatorExpression(
                                                                        new BinaryOperatorExpression(
                                                                            new IdentifierExpression(
                                                                                "s",
                                                                                _emptyId
                                                                            ),
                                                                            AphidTokenType.MemberOperator,
                                                                            new IdentifierExpression(
                                                                                "name",
                                                                                _emptyId
                                                                            )
                                                                        ),
                                                                        AphidTokenType.BinaryOrOperator,
                                                                        new BinaryOperatorExpression(
                                                                            new IdentifierExpression(
                                                                                "convention",
                                                                                _emptyId
                                                                            ),
                                                                            AphidTokenType.MemberOperator,
                                                                            new IdentifierExpression(
                                                                                "camelCase",
                                                                                _emptyId
                                                                            )
                                                                        )
                                                                    )
                                                                )
                                                            ),
                                                            new TextExpression(
                                                                ")\r\n                    { \r\n                        for (var i = 0; i "
                                                            ),
                                                            new TextExpression(
                                                                "< "
                                                            ),
                                                            new GatorEmitExpression(
                                                                new IdentifierExpression(
                                                                    "localName",
                                                                    _emptyId
                                                                )
                                                            ),
                                                            new TextExpression(
                                                                ".Length; i++)\r\n                        {\r\n                            var c = "
                                                            ),
                                                            new GatorEmitExpression(
                                                                new IdentifierExpression(
                                                                    "localName",
                                                                    _emptyId
                                                                )
                                                            ),
                                                            new TextExpression(
                                                                "[i];\r\n\r\n                            switch (c)\r\n                            {\r\n                                "
                                                            ),
                                                            new GatorEmitExpression(
                                                                new BinaryOperatorExpression(
                                                                    new BinaryOperatorExpression(
                                                                        new BinaryOperatorExpression(
                                                                            new BinaryOperatorExpression(
                                                                                new CallExpression(
                                                                                    new BinaryOperatorExpression(
                                                                                        new IdentifierExpression(
                                                                                            "s",
                                                                                            _emptyId
                                                                                        ),
                                                                                        AphidTokenType.MemberOperator,
                                                                                        new IdentifierExpression(
                                                                                            "func",
                                                                                            _emptyId
                                                                                        )
                                                                                    ),
                                                                                    new List<AphidExpression>
                                                                                    {
                                                                                    }
                                                                                ),
                                                                                AphidTokenType.SelectOperator,
                                                                                new FunctionExpression(
                                                                                    new List<AphidExpression>
                                                                                    {
                                                                                    },
                                                                                    new List<AphidExpression>
                                                                                    {
                                                                                        new UnaryOperatorExpression(
                                                                                            AphidTokenType.retKeyword,
                                                                                            new CallExpression(
                                                                                                new BinaryOperatorExpression(
                                                                                                    new ImplicitArgumentExpression(
                                                                                                        AphidTokenType.ImplicitArgumentOperator
                                                                                                    ),
                                                                                                    AphidTokenType.MemberOperator,
                                                                                                    new IdentifierExpression(
                                                                                                        "byte",
                                                                                                        _emptyId
                                                                                                    )
                                                                                                ),
                                                                                                new List<AphidExpression>
                                                                                                {
                                                                                                }
                                                                                            ),
                                                                                            false
                                                                                        ),
                                                                                    }
                                                                                )
                                                                            ),
                                                                            AphidTokenType.SelectOperator,
                                                                            new IdentifierExpression(
                                                                                "hex",
                                                                                _emptyId
                                                                            )
                                                                        ),
                                                                        AphidTokenType.SelectOperator,
                                                                        new PartialFunctionExpression(
                                                                            new CallExpression(
                                                                                new IdentifierExpression(
                                                                                    "format",
                                                                                    _emptyId
                                                                                ),
                                                                                new List<AphidExpression>
                                                                                {
                                                                                    new StringExpression(
                                                                                        "\"case '\\\\x{0}':\""
                                                                                    ),
                                                                                }
                                                                            )
                                                                        )
                                                                    ),
                                                                    AphidTokenType.PipelineOperator,
                                                                    new PartialFunctionExpression(
                                                                        new CallExpression(
                                                                            new IdentifierExpression(
                                                                                "join",
                                                                                _emptyId
                                                                            ),
                                                                            new List<AphidExpression>
                                                                            {
                                                                                new StringExpression(
                                                                                    "'\\r\\n'"
                                                                                ),
                                                                            }
                                                                        )
                                                                    )
                                                                )
                                                            ),
                                                            new TextExpression(
                                                                "\r\n                                    return false;                                    \r\n                            }\r\n                        }\r\n\r\n                        return true;\r\n                    }\r\n                }\r\n            }\r\n        "
                                                            ),
                                                            new GatorOpenExpression(
                                                            ),
                                                        }
                                                    ),
                                                }
                                            ),
                                            AphidTokenType.MemberOperator,
                                            new IdentifierExpression(
                                                "ToString",
                                                _emptyId
                                            )
                                        ),
                                        new List<AphidExpression>
                                        {
                                        }
                                    ),
                                    false
                                ),
                            }
                        )
                    )
                ),
                new BinaryOperatorExpression(
                    new IdentifierExpression(
                        "results",
                        new List<IdentifierExpression>
                        {
                            new IdentifierExpression(
                                "var",
                                _emptyId
                            ),
                        }
                    ),
                    AphidTokenType.AssignmentOperator,
                    new BinaryOperatorExpression(
                        new BinaryOperatorExpression(
                            new IdentifierExpression(
                                "csUnits",
                                _emptyId
                            ),
                            AphidTokenType.PipelineOperator,
                            new PartialFunctionExpression(
                                new CallExpression(
                                    new IdentifierExpression(
                                        "join",
                                        _emptyId
                                    ),
                                    new List<AphidExpression>
                                    {
                                        new StringExpression(
                                            "'\\r\\n'"
                                        ),
                                    }
                                )
                            )
                        ),
                        AphidTokenType.PipelineOperator,
                        new BinaryOperatorExpression(
                            new IdentifierExpression(
                                "csharp",
                                _emptyId
                            ),
                            AphidTokenType.MemberOperator,
                            new IdentifierExpression(
                                "compileAsm",
                                _emptyId
                            )
                        )
                    )
                ),
                new BinaryOperatorExpression(
                    new IdentifierExpression(
                        "t",
                        new List<IdentifierExpression>
                        {
                            new IdentifierExpression(
                                "var",
                                _emptyId
                            ),
                        }
                    ),
                    AphidTokenType.AssignmentOperator,
                    new CallExpression(
                        new BinaryOperatorExpression(
                            new BinaryOperatorExpression(
                                new IdentifierExpression(
                                    "results",
                                    _emptyId
                                ),
                                AphidTokenType.MemberOperator,
                                new IdentifierExpression(
                                    "CompiledAssembly",
                                    _emptyId
                                )
                            ),
                            AphidTokenType.MemberOperator,
                            new IdentifierExpression(
                                "GetType",
                                _emptyId
                            )
                        ),
                        new List<AphidExpression>
                        {
                            new StringExpression(
                                "'Damselfly.Components.WindowsPath'"
                            ),
                        }
                    )
                ),
                new BinaryOperatorExpression(
                    new BinaryOperatorExpression(
                        new IdentifierExpression(
                            "WindowsPath",
                            _emptyId
                        ),
                        AphidTokenType.MemberOperator,
                        new IdentifierExpression(
                            "IsValidFileName",
                            _emptyId
                        )
                    ),
                    AphidTokenType.AssignmentOperator,
                    new CallExpression(
                        new BinaryOperatorExpression(
                            new ArrayAccessExpression(
                                new BinaryOperatorExpression(
                                    new BinaryOperatorExpression(
                                        new IdentifierExpression(
                                            "t",
                                            _emptyId
                                        ),
                                        AphidTokenType.MemberOperator,
                                        new IdentifierExpression(
                                            "IsValidFileName",
                                            _emptyId
                                        )
                                    ),
                                    AphidTokenType.MemberOperator,
                                    new IdentifierExpression(
                                        "Members",
                                        _emptyId
                                    )
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
                                "CreateDelegate",
                                _emptyId
                            )
                        ),
                        new List<AphidExpression>
                        {
                            new BinaryOperatorExpression(
                                new IdentifierExpression(
                                    "WindowsPath",
                                    _emptyId
                                ),
                                AphidTokenType.MemberOperator,
                                new IdentifierExpression(
                                    "IsValidFileNameDelegate",
                                    _emptyId
                                )
                            ),
                        }
                    )
                ),
                new BinaryOperatorExpression(
                    new BinaryOperatorExpression(
                        new IdentifierExpression(
                            "WindowsPath",
                            _emptyId
                        ),
                        AphidTokenType.MemberOperator,
                        new IdentifierExpression(
                            "IsValidPath",
                            _emptyId
                        )
                    ),
                    AphidTokenType.AssignmentOperator,
                    new CallExpression(
                        new BinaryOperatorExpression(
                            new ArrayAccessExpression(
                                new BinaryOperatorExpression(
                                    new BinaryOperatorExpression(
                                        new IdentifierExpression(
                                            "t",
                                            _emptyId
                                        ),
                                        AphidTokenType.MemberOperator,
                                        new IdentifierExpression(
                                            "IsValidPath",
                                            _emptyId
                                        )
                                    ),
                                    AphidTokenType.MemberOperator,
                                    new IdentifierExpression(
                                        "Members",
                                        _emptyId
                                    )
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
                                "CreateDelegate",
                                _emptyId
                            )
                        ),
                        new List<AphidExpression>
                        {
                            new BinaryOperatorExpression(
                                new IdentifierExpression(
                                    "WindowsPath",
                                    _emptyId
                                ),
                                AphidTokenType.MemberOperator,
                                new IdentifierExpression(
                                    "IsValidPathDelegate",
                                    _emptyId
                                )
                            ),
                        }
                    )
                ),
            }
        )
    ),
}

            );

    }
}


