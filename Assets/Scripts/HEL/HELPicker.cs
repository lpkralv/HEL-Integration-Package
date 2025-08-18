/*  HELPicker.cs

    This class selects a random Modifier from the modweight distribution. 
    It is used by the Editor analysis, but is not needed for HEL evaluation.
*/

using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// This is an amazing algorithm for defining a probability distribution of items
/// with a weight for each and sampling a random item from this distribution.
/// It does a simple O(N) setup step in the constructor, and the Sample()
/// function is O(1). Awesome! BTW, this is called the Alias method.
/// Used for selecting random mods based on their weight distribution.
/// </summary>
public class HELPicker
{
    /// <summary>
    /// Alias table mapping indices to their alternative indices for the Alias method.
    /// </summary>
    private readonly int[] alias;
    
    /// <summary>
    /// Probability table storing the adjusted probabilities for each index.
    /// </summary>
    private readonly double[] probability;
    
    /// <summary>
    /// The number of items in the distribution.
    /// </summary>
    private readonly int n;
    
    /// <summary>
    /// Random number generator used for sampling.
    /// </summary>
    private readonly Random rand = new Random();

    /// <summary>
    /// Initializes a new HELPicker with the specified weights and constructs the Alias method tables.
    /// Uses the 'Alias' method to enable O(1) sampling from the weighted distribution regardless
    /// of the number of items.
    /// </summary>
    /// <param name="inWeights">
    /// The ordered list of mod weights. MODs are identified by their index in the list.
    /// All weights should be positive integers.
    /// </param>
    public HELPicker(List<int> inWeights)
    {
        n = inWeights.Count;
        List<double> weights = inWeights.ConvertAll(x => (double)x); //Algorithm assumes weights are doubles
        alias = new int[n];
        probability = new double[n];
        double sum = weights.Sum();
        double[] normalized = weights.Select(w => w * n / sum).ToArray();

        Queue<int> small = new Queue<int>();
        Queue<int> large = new Queue<int>();

        for (int i = 0; i < n; i++)
        {
            if (normalized[i] < 1.0)
                small.Enqueue(i);
            else
                large.Enqueue(i);
        }

        while (small.Count > 0 && large.Count > 0)
        {
            int less = small.Dequeue();
            int more = large.Dequeue();

            probability[less] = normalized[less];
            alias[less] = more;

            normalized[more] = normalized[more] - (1.0 - normalized[less]);
            if (normalized[more] < 1.0)
                small.Enqueue(more);
            else
                large.Enqueue(more);
        }

        while (large.Count > 0)
        {
            probability[large.Dequeue()] = 1.0;
        }

        while (small.Count > 0)
        {
            probability[small.Dequeue()] = 1.0;
        }
    }

    /// <summary>
    /// Samples a random index from the weighted distribution in O(1) time.
    /// Each index is selected with probability proportional to its original weight.
    /// </summary>
    /// <returns>The index of the selected item based on the weighted distribution</returns>
    public int Sample()
    {
        int i = rand.Next(n);
        // Use a uniform random number to decide between the index and its alias.
        return rand.NextDouble() < probability[i] ? i : alias[i];
    }
}

/*
The ALIAS method is an efficient way to sample from a discrete probability distribution in 
constant O(1) time after an initial O(N) preprocessing. Here’s a concise explanation of how it works:

Preprocessing Stage - O(N)  Called ONCE during object initialization

    Normalize the Weights:
        Convert the list of weights into probabilities that sum to 1. 
        Multiply each probability by the number of items NN so that on average, 
        each normalized probability equals 1.

    Create Two Buckets:
        Partition the indices into two groups:
            Small: Indices whose normalized probability is less than 1.
            Large: Indices whose normalized probability is at least 1.

    Construct the Tables:
        Probability Table: For each index, store the normalized probability.
        Alias Table: For indices in the "small" bucket, assign an alias from the "large" bucket.

        The idea is to “balance” the buckets. For an index in the "small" bucket, its deficit 
        (1 minus its normalized probability) is compensated by taking excess probability from 
        a corresponding index in the "large" bucket. Adjust the excess of the "large" index 
        accordingly. Continue this process until all indices are balanced, so that each index 
        in the table effectively represents a “bucket” with a total probability of 1.

Sampling Stage - O(1)  Called MANY times

    Random Index Selection:
        Pick an index uniformly at random from 0 to N−1N−1.

    Decide Using the Probability Table:
        Generate a random number between 0 and 1. If this number is less than the probability 
        stored at that index, return the index. Otherwise, return the alias stored for that index.

This two-step process ensures that each index is selected according to its original probability, 
but the work done during each sampling is constant time. The efficiency comes from offloading the 
heavy computation to the preprocessing step.

In summary, by restructuring the problem into two lookup tables—one for adjusted probabilities 
and one for aliases—the alias method allows quick, constant-time sampling from any discrete distribution.
*/
