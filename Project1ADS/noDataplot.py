import matplotlib.pyplot as plt
import numpy as np
# inslatted numpy and matplotlib

# Values of n to plot
n_values = np.arange(1, 21)  # Plot for n from 1 to 20

# Complexity functions
O_n2 = n_values ** 2  # O(n^2)
O_2n = (2 ** n_values) / 4  # O(2^n)

# Plotting the functions
plt.plot(n_values, O_n2, label='O(n^2)', marker='o')
plt.plot(n_values, O_2n, label='O(2^n)', marker='x')

# Labeling the plot
plt.xlabel('n (Input Size)')
plt.ylabel('Complexity Growth')
plt.title('Comparison of O(n^2) and O(2^n) Fibonacci algorithm Complexities')
# plt.yscale('log')  # Optional: Use logarithmic scale for clearer comparison
plt.legend()

# Show grid and plot
plt.grid(True)
plt.show()