﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine.EventSystems;

namespace UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Components.Auto
{
    public abstract class AutoUIBehavior : UIBehaviour
    {
        private readonly IList<FieldInfo> awakeFields;
        private readonly IList<FieldInfo> enableFields;
        private readonly IList<FieldInfo> startFields;

        protected AutoUIBehavior()
        {
            var fields = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(x => x.GetCustomAttribute<InjectAttribute>() != null);

            awakeFields = fields
                .Where(x => x.GetCustomAttribute<InjectAttribute>().Time == InjectionTime.Awake)
                .ToList();
            enableFields = fields
                .Where(x => x.GetCustomAttribute<InjectAttribute>().Time == InjectionTime.Enable)
                .ToList();
            startFields = fields
                .Where(x => x.GetCustomAttribute<InjectAttribute>().Time == InjectionTime.Start)
                .ToList();
        }

        #region Caller Methods for Builtin Methods

        protected void InjectFieldsOnAwake()
        {
            foreach (var awakeField in awakeFields)
            {
                InjectField(awakeField);
            }
        }

        protected void InjectFieldsOnEnable()
        {
            foreach (var enableField in enableFields)
            {
                InjectField(enableField);
            }
        }

        protected void InjectFieldsOnStart()
        {
            foreach (var startField in startFields)
            {
                InjectField(startField);
            }
        }

        #endregion

        private void InjectField(FieldInfo field)
        {
            switch (field.GetCustomAttribute<InjectAttribute>().Place)
            {
                case InjectionPlace.Current:
                    field.SetValue(this, field.FieldType.IsArray ? GetComponents(field.FieldType.GetElementType()) : GetComponent(field.FieldType));
                    break;
                case InjectionPlace.Children:
                    field.SetValue(this, field.FieldType.IsArray ? GetComponentsInChildren(field.FieldType.GetElementType()) : GetComponentInChildren(field.FieldType));
                    break;
                case InjectionPlace.Parents:
                    field.SetValue(this, field.FieldType.IsArray ? GetComponentsInParent(field.FieldType.GetElementType()) : GetComponentInParent(field.FieldType));
                    break;
                default:
                    throw new NotImplementedException(field.GetCustomAttribute<InjectAttribute>().Place.ToString());
            }
        }
    }
}