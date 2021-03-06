﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiDimensionalPeakFinding.PeakDetection
{
    public class Point : IComparable<Point>
    {
        public int ScanLc
        {
            get { return this.ScanLcIndex + this.ScanLcOffset; }
        }

        public int ScanIms
        {
            get { return this.ScanImsIndex + this.ScanImsOffset; }
        }

        public int ScanLcIndex { get; private set; }
        public int ScanLcOffset { get; private set; }
        public int ScanImsIndex { get; private set; }
        public int ScanImsOffset { get; private set; }

        public double Intensity { get; set; }

        public Point North { get; set; }
        public Point South { get; set; }
        public Point East { get; set; }
        public Point West { get; set; }
        public Point NorthEast { get; set; }
        public Point NorthWest { get; set; }
        public Point SouthEast { get; set; }
        public Point SouthWest { get; set; }

        public bool IsBackground { get; set; }
        public bool IsSaturated { get; set; }
        public FeatureBlob FeatureBlob { get; set; }

        public Point(int scanLcIndex, int scanLcOffset, int scanImsIndex, int scanImsOffset, double intensity, bool isSaturated = false)
        {
            this.ScanLcIndex = scanLcIndex;
            this.ScanLcOffset = scanLcOffset;
            this.ScanImsIndex = scanImsIndex;
            this.ScanImsOffset = scanImsOffset;
            this.Intensity = intensity;
            this.IsBackground = false;
            this.IsSaturated = isSaturated;
        }

        public HigherNeighborResult FindMoreIntenseNeighbors(out FeatureBlob feature)
        {
            int featureCount = 0;
            FeatureBlob savedFeature = null;
            feature = null;

            if (this.North != null && this.North.Intensity >= this.Intensity)
            {
                if(this.North.IsBackground) return HigherNeighborResult.Background;
                savedFeature = this.North.FeatureBlob;
            }
            if (this.South != null && this.South.Intensity >= this.Intensity)
            {
                if (this.South.IsBackground) return HigherNeighborResult.Background;
                if (savedFeature != null)
                {
                    if (this.South.FeatureBlob != null && savedFeature != this.South.FeatureBlob)
                    {
                        if (this.South.FeatureBlob.PointList.Count > savedFeature.PointList.Count)
                        {
                            savedFeature = this.South.FeatureBlob;
                            featureCount++;
                        }
                        //return HigherNeighborResult.MultipleFeatures;
                    }
                }
                else
                {
                    savedFeature = this.South.FeatureBlob;
                }
            }
            if (this.East != null && this.East.Intensity >= this.Intensity)
            {
                if (this.East.IsBackground) return HigherNeighborResult.Background;
                if (savedFeature != null)
                {
                    if (this.East.FeatureBlob != null && savedFeature != this.East.FeatureBlob)
                    {
                        if (this.East.FeatureBlob.PointList.Count > savedFeature.PointList.Count)
                        {
                            savedFeature = this.East.FeatureBlob;
                            featureCount++;
                        }
                        //return HigherNeighborResult.MultipleFeatures;
                    }
                }
                else
                {
                    savedFeature = this.East.FeatureBlob;
                }
            }
            if (this.West != null && this.West.Intensity >= this.Intensity)
            {
                if (this.West.IsBackground) return HigherNeighborResult.Background;
                if (savedFeature != null)
                {
                    if (this.West.FeatureBlob != null && savedFeature != this.West.FeatureBlob)
                    {
                        if (this.West.FeatureBlob.PointList.Count > savedFeature.PointList.Count)
                        {
                            savedFeature = this.West.FeatureBlob;
                            featureCount++;
                        }
                        //return HigherNeighborResult.MultipleFeatures;
                    }
                }
                else
                {
                    savedFeature = this.West.FeatureBlob;
                }
            }
            if (this.NorthEast != null && this.NorthEast.Intensity >= this.Intensity)
            {
                if (this.NorthEast.IsBackground) return HigherNeighborResult.Background;
                if (savedFeature != null)
                {
                    if (this.NorthEast.FeatureBlob != null && savedFeature != this.NorthEast.FeatureBlob)
                    {
                        if (this.NorthEast.FeatureBlob.PointList.Count > savedFeature.PointList.Count)
                        {
                            savedFeature = this.NorthEast.FeatureBlob;
                            featureCount++;
                        }
                        //return HigherNeighborResult.MultipleFeatures;
                    }
                }
                else
                {
                    savedFeature = this.NorthEast.FeatureBlob;
                }
            }
            if (this.NorthWest != null && this.NorthWest.Intensity >= this.Intensity)
            {
                if (this.NorthWest.IsBackground) return HigherNeighborResult.Background;
                if (savedFeature != null)
                {
                    if (this.NorthWest.FeatureBlob != null && savedFeature != this.NorthWest.FeatureBlob)
                    {
                        if (this.NorthWest.FeatureBlob.PointList.Count > savedFeature.PointList.Count)
                        {
                            savedFeature = this.NorthWest.FeatureBlob;
                            featureCount++;
                        }
                        //return HigherNeighborResult.MultipleFeatures;
                    }
                }
                else
                {
                    savedFeature = this.NorthWest.FeatureBlob;
                }
            }
            if (this.SouthEast != null && this.SouthEast.Intensity >= this.Intensity)
            {
                if (this.SouthEast.IsBackground) return HigherNeighborResult.Background;
                if (savedFeature != null)
                {
                    if (this.SouthEast.FeatureBlob != null && savedFeature != this.SouthEast.FeatureBlob)
                    {
                        if (this.SouthEast.FeatureBlob.PointList.Count > savedFeature.PointList.Count)
                        {
                            savedFeature = this.SouthEast.FeatureBlob;
                            featureCount++;
                        }
                        //return HigherNeighborResult.MultipleFeatures;
                    }
                }
                else
                {
                    savedFeature = this.SouthEast.FeatureBlob;
                }
            }
            if (this.SouthWest != null && this.SouthWest.Intensity >= this.Intensity)
            {
                if (this.SouthWest.IsBackground) return HigherNeighborResult.Background;
                if (savedFeature != null)
                {
                    if (this.SouthWest.FeatureBlob != null && savedFeature != this.SouthWest.FeatureBlob)
                    {
                        if (this.SouthWest.FeatureBlob.PointList.Count > savedFeature.PointList.Count)
                        {
                            savedFeature = this.SouthWest.FeatureBlob;
                            featureCount++;
                        }
                        //return HigherNeighborResult.MultipleFeatures;
                    }
                }
                else
                {
                    savedFeature = this.SouthWest.FeatureBlob;
                }
            }

            if (savedFeature == null)
            {
                return HigherNeighborResult.None;
            }

            feature = savedFeature;

            if(featureCount > 1)
            {
                return HigherNeighborResult.MultipleFeatures;
            }

            return HigherNeighborResult.OneFeature;
        }

        public bool Equals(Point other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.ScanLcIndex == ScanLcIndex && other.ScanImsIndex == ScanImsIndex;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Point)) return false;
            return Equals((Point) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (ScanLcIndex * 397) ^ ScanImsIndex;
            }
        }

        public static bool operator ==(Point left, Point right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Point left, Point right)
        {
            return !Equals(left, right);
        }

        public int CompareTo(Point other)
        {
            if (this.ScanLcIndex != other.ScanLcIndex) return this.ScanLcIndex.CompareTo(other.ScanLcIndex);
            return this.ScanImsIndex.CompareTo(other.ScanImsIndex);
        }

        public override string ToString()
        {
            return string.Format("ScanLcIndex: {0}, ScanImsIndex: {1}, Intensity: {2}", ScanLcIndex, ScanImsIndex, Intensity);
        }
    }
}
