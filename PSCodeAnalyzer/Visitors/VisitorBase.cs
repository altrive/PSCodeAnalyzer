using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Language;
using System.Text;
using System.Threading.Tasks;

namespace PSCodeAnalyzer
{
    public class VisitorBase : AstVisitor
    {
        public override AstVisitAction VisitErrorStatement(ErrorStatementAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitErrorExpression(ErrorExpressionAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitScriptBlock(ScriptBlockAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitParamBlock(ParamBlockAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitNamedBlock(NamedBlockAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitTypeConstraint(TypeConstraintAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitAttribute(AttributeAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitParameter(ParameterAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitTypeExpression(TypeExpressionAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitFunctionDefinition(FunctionDefinitionAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitStatementBlock(StatementBlockAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitIfStatement(IfStatementAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitTrap(TrapStatementAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitSwitchStatement(SwitchStatementAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitDataStatement(DataStatementAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitForEachStatement(ForEachStatementAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitDoWhileStatement(DoWhileStatementAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitForStatement(ForStatementAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitWhileStatement(WhileStatementAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitCatchClause(CatchClauseAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitTryStatement(TryStatementAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitBreakStatement(BreakStatementAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitContinueStatement(ContinueStatementAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitReturnStatement(ReturnStatementAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitExitStatement(ExitStatementAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitThrowStatement(ThrowStatementAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitDoUntilStatement(DoUntilStatementAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitAssignmentStatement(AssignmentStatementAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitPipeline(PipelineAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitCommand(CommandAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitCommandExpression(CommandExpressionAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitCommandParameter(CommandParameterAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitMergingRedirection(MergingRedirectionAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitFileRedirection(FileRedirectionAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitBinaryExpression(BinaryExpressionAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitUnaryExpression(UnaryExpressionAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitConvertExpression(ConvertExpressionAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitConstantExpression(ConstantExpressionAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitStringConstantExpression(StringConstantExpressionAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitSubExpression(SubExpressionAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitUsingExpression(UsingExpressionAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitVariableExpression(VariableExpressionAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitMemberExpression(MemberExpressionAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitInvokeMemberExpression(InvokeMemberExpressionAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitArrayExpression(ArrayExpressionAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitArrayLiteral(ArrayLiteralAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitHashtable(HashtableAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitScriptBlockExpression(ScriptBlockExpressionAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitParenExpression(ParenExpressionAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitExpandableStringExpression(ExpandableStringExpressionAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitIndexExpression(IndexExpressionAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitAttributedExpression(AttributedExpressionAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitBlockStatement(BlockStatementAst ast)
        {
            return AstVisitAction.Continue;
        }

        public override AstVisitAction VisitNamedAttributeArgument(NamedAttributeArgumentAst ast)
        {
            return AstVisitAction.Continue;
        }
    }
}
