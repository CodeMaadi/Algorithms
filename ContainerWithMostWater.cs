// https://leetcode.com/problems/container-with-most-water/description/
public class Solution {
    public int MaxArea(int[] height) {
        return MaxAreaBruteForce(height);
    }
    
    public int MaxAreaImproved(int[] height) {
        
    }
    
    public int MaxAreaBruteForce(int[] height) {
        if (height == null || height.Length <= 1) return 0;
        
        int[,] maxAreas = new int[height.Length,height.Length];
        int max = Int32.MinValue;
        for (int i = 0; i < height.Length; i++)
        {
            for (int j = i; j < height.Length; j++)
            {
                if (i == j)
                {
                    maxAreas[i,j] = 0;
                    continue;
                }
                
                maxAreas[i,j] = 0; // Set to zero just in case.                
                maxAreas[i,j] = (j-i) * Math.Min(height[i], height[j]);
                max = Math.Max(max, maxAreas[i,j]);                
            }
        }
        
        return max;
    }
}