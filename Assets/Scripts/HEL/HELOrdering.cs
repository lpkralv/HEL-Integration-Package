//#define MYDEBUG   //Uncomment to activate debugging

using System;
using System.Collections.Generic;
using Vertex = System.Tuple<int, int>;

/// <summary>
/// Provides statement dependency analysis and cycle detection for HEL equations.
/// Analyzes variable dependencies between statements to identify execution order requirements
/// and detect circular dependencies that would prevent proper evaluation.
/// </summary>
public class Orderer
{
    /// <summary>
    /// Analyzes a list of statements to detect dependency cycles and groups them by cycle membership count.
    /// Builds a dependency graph based on variable assignments and usages, then uses depth-first search
    /// to find all simple cycles in the graph.
    /// </summary>
    /// <param name="statements">The list of statements to analyze for dependencies</param>
    /// <returns>
    /// A dictionary where keys are cycle membership counts (0 = no cycles, 1+ = number of cycles the statement participates in)
    /// and values are lists of statements with that membership count
    /// </returns>
    /// <remarks>
    /// The algorithm:
    /// 1. Builds a dependency graph where edges represent "A assigns to variable that B uses"
    /// 2. Maps variables to their assignment and usage statements
    /// 3. Detects all simple cycles using DFS with cycle signature normalization to avoid duplicates
    /// 4. Groups statements by how many cycles they participate in
    /// 
    /// Statements with cycle count 0 can be executed without dependency issues.
    /// Statements with cycle count > 0 are involved in circular dependencies.
    /// </remarks>
    public static Dictionary<int, List<Statement>> AnalyzeStatementCycles(List<Statement> statements)
    {
        #if MYDEBUG
            var allCycles = new List<List<Statement>>();  // keep track of cycles
        #endif

        // Step 1: Build the dependency graph
        var graph = new Dictionary<Statement, List<Statement>>();
        foreach (var stmt in statements)
        {
            graph[stmt] = new List<Statement>();
        }

        // Step 2: Map variable names to statements
        var variableAssignments = new Dictionary<string, List<Statement>>(StringComparer.OrdinalIgnoreCase);
        var variableUsages = new Dictionary<string, List<Statement>>(StringComparer.OrdinalIgnoreCase);

        foreach (var stmt in statements)
        {
            if (stmt.LHSVariable != null)
            {
                var varName = stmt.LHSVariable.Value;
                if (!variableAssignments.ContainsKey(varName))
                    variableAssignments[varName] = new List<Statement>();
                variableAssignments[varName].Add(stmt);
            }

            foreach (var rhs in stmt.RHSVariables)
            {
                var varName = rhs.Value;
                if (!variableUsages.ContainsKey(varName))
                    variableUsages[varName] = new List<Statement>();
                variableUsages[varName].Add(stmt);
            }
        }

        // Step 3: Add edges to graph
        foreach (var varName in variableAssignments.Keys)
        {
            if (!variableUsages.ContainsKey(varName)) continue;

            foreach (var assign in variableAssignments[varName])
            {
                foreach (var use in variableUsages[varName])
                {
                    if (assign != use)
                        graph[assign].Add(use);
                }
            }
        }

        #if MYDEBUG
        Console.WriteLine("--- Dependency Graph ---");
        foreach (var stmt in graph.Keys) 
        {
            Console.Write($"{stmt.dumpStr()}.{stmt.dumpVertex()} <-- ");
            foreach (var next in graph[stmt])
            {
                Console.Write($"{next.dumpStr()}.{next.dumpVertex()}; ");
            }
            Console.WriteLine(" ");
        }
        #endif

        // Step 4: Detect all simple cycles using DFS
        var cycleMembershipCount = new Dictionary<Statement, int>();
        foreach (var stmt in statements)
            cycleMembershipCount[stmt] = 0;

        var visited = new HashSet<Statement>();
        var stack = new Stack<Statement>();
        var seenCycleSignatures = new HashSet<string>();

        /// <summary>
        /// Normalizes a cycle by rotating it so the statement with the minimum index comes first.
        /// This ensures cycles are represented consistently regardless of starting point.
        /// </summary>
        /// <param name="cycle">The cycle to normalize</param>
        /// <returns>The normalized cycle starting with the minimum index statement</returns>
        List<Statement> NormalizeCycle(List<Statement> cycle)
        {
            int minIndex = cycle.Select((stmt, i) => (stmt.Index, i)).Min().i;
            return cycle.Skip(minIndex).Concat(cycle.Take(minIndex)).ToList();
        }

        /// <summary>
        /// Creates a unique signature string for a cycle based on statement indices.
        /// Used to avoid counting the same cycle multiple times during detection.
        /// </summary>
        /// <param name="cycle">The cycle to create a signature for</param>
        /// <returns>A string signature representing the cycle uniquely</returns>
        string GetCycleSignature(List<Statement> cycle)
        {
            var norm = NormalizeCycle(cycle);
            return string.Join("->", norm.Select(s => s.Index));
        }

        /// <summary>
        /// Performs depth-first search to detect cycles in the dependency graph.
        /// Uses recursion stack tracking to identify back edges that form cycles.
        /// </summary>
        /// <param name="current">The current statement being visited</param>
        /// <param name="recStack">Set of statements in the current recursion path</param>
        void DFS(Statement current, HashSet<Statement> recStack)
        {
            visited.Add(current);
            recStack.Add(current);
            stack.Push(current);

            foreach (var neighbor in graph[current])
            {
                if (!recStack.Contains(neighbor))
                {
                    if (!visited.Contains(neighbor))
                        DFS(neighbor, recStack);
                }
                else
                {
                    // Found a cycle: current → ... → neighbor
                    var cycle = stack.Reverse().SkipWhile(s => s != neighbor).ToList();

                    if (cycle.Count > 1)
                    {
                        var sig = GetCycleSignature(cycle);
                        if (!seenCycleSignatures.Contains(sig))
                        {
                            seenCycleSignatures.Add(sig);
            #if MYDEBUG
                            allCycles.Add(cycle);
            #endif
                            foreach (var s in cycle)
                                cycleMembershipCount[s]++;
                        }
                    }
                }
            }

            recStack.Remove(current);
            stack.Pop();
        }

        foreach (var stmt in statements)
        {
            visited.Clear();
            DFS(stmt, new HashSet<Statement>());
        }

        // Step 5: Group by number of cycles
        var grouped = new Dictionary<int, List<Statement>>();
        foreach (var kvp in cycleMembershipCount)
        {
            int count = kvp.Value;
            if (!grouped.ContainsKey(count))
                grouped[count] = new List<Statement>();
            grouped[count].Add(kvp.Key);
        }

    #if MYDEBUG
        Console.WriteLine($"\nDetected {allCycles.Count} cycle(s):");
        int cycleNum = 1;
        foreach (var cycle in allCycles)
        {
            Console.WriteLine($"\nCycle {cycleNum++}:");
            foreach (var stmt in cycle)
            {
                Console.WriteLine($"  [{stmt.Index}] {stmt.dumpStr()}");
            }
        }
    #endif


        return grouped;
    }

}