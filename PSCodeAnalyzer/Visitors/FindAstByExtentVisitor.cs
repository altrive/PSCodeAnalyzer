using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Language;
using System.Text;
using System.Threading.Tasks;

namespace PSCodeAnalyzer.Visitors
{
    //Visitor to find specific AST by token extent.(Optimized by extent information)
    class FindAstByExtentVisitor<T> : AstVisitor
        where T : Ast
    {
        private readonly Token _token;

        public T Result { get; set; }

        public FindAstByExtentVisitor(Token token)
        {
            this._token = token;
        }

        protected AstVisitAction Check(Ast ast)
        {
            //Check token is contained in tree.
            if (!_token.Extent.IsContained(ast.Extent))
                return AstVisitAction.StopVisit;

            //If not ast is not target type. continue ast traversal.
            if (!(ast is T))
                return AstVisitAction.Continue;

            //found target ast
            Result = (T)ast;
            return AstVisitAction.StopVisit;
        }

        public override AstVisitAction VisitErrorStatement(ErrorStatementAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitErrorExpression(ErrorExpressionAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitScriptBlock(ScriptBlockAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitParamBlock(ParamBlockAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitNamedBlock(NamedBlockAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitTypeConstraint(TypeConstraintAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitAttribute(AttributeAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitParameter(ParameterAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitTypeExpression(TypeExpressionAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitFunctionDefinition(FunctionDefinitionAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitStatementBlock(StatementBlockAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitIfStatement(IfStatementAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitTrap(TrapStatementAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitSwitchStatement(SwitchStatementAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitDataStatement(DataStatementAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitForEachStatement(ForEachStatementAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitDoWhileStatement(DoWhileStatementAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitForStatement(ForStatementAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitWhileStatement(WhileStatementAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitCatchClause(CatchClauseAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitTryStatement(TryStatementAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitBreakStatement(BreakStatementAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitContinueStatement(ContinueStatementAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitReturnStatement(ReturnStatementAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitExitStatement(ExitStatementAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitThrowStatement(ThrowStatementAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitDoUntilStatement(DoUntilStatementAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitAssignmentStatement(AssignmentStatementAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitPipeline(PipelineAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitCommand(CommandAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitCommandExpression(CommandExpressionAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitCommandParameter(CommandParameterAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitMergingRedirection(MergingRedirectionAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitFileRedirection(FileRedirectionAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitBinaryExpression(BinaryExpressionAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitUnaryExpression(UnaryExpressionAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitConvertExpression(ConvertExpressionAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitConstantExpression(ConstantExpressionAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitStringConstantExpression(StringConstantExpressionAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitSubExpression(SubExpressionAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitUsingExpression(UsingExpressionAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitVariableExpression(VariableExpressionAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitMemberExpression(MemberExpressionAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitInvokeMemberExpression(InvokeMemberExpressionAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitArrayExpression(ArrayExpressionAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitArrayLiteral(ArrayLiteralAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitHashtable(HashtableAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitScriptBlockExpression(ScriptBlockExpressionAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitParenExpression(ParenExpressionAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitExpandableStringExpression(ExpandableStringExpressionAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitIndexExpression(IndexExpressionAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitAttributedExpression(AttributedExpressionAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitBlockStatement(BlockStatementAst ast)
        {
            return Check(ast);
        }

        public override AstVisitAction VisitNamedAttributeArgument(NamedAttributeArgumentAst ast)
        {
            return Check(ast);
        }
    }
}
